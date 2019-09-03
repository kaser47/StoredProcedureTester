using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoredProcedureTester
{
    public partial class Form1 : Form
    {
        private StoredProcedureTest currentTest;
        private LogHelper logHelper;

        public Form1()
        {
            InitializeComponent();
            SetupDefaults();
            SetupControls();
        }

        private void SetupDefaults()
        {
            currentTest = new StoredProcedureTest();
            logHelper = new LogHelper();
            logHelper.logs.ListChanged += LogsOnListChanged;
            logHelper.Log("Ready");
            lbUnoptimisedParameters.MouseDoubleClick += LbUnoptimisedParametersOnMouseDoubleClick;
            lbOptimisedParameters.MouseDoubleClick += LbOptimisedParametersOnMouseDoubleClick;
            cbType.SelectedIndexChanged += CbTypeOnSelectedIndexChanged;
            dtpValue.Hide();
            chkBoxValue.Hide();
            btnGenerateGuid.Hide();
        }

        private void CbTypeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            TestParameterDataType dataType = (TestParameterDataType) cbType.SelectedItem;

            switch (dataType)
            {
                case TestParameterDataType.Guid:
                    tbValue.Show();
                    chkBoxValue.Hide();
                    dtpValue.Hide();
                    btnGenerateGuid.Show();
                    break;
                case TestParameterDataType.DateTime:
                    tbValue.Hide();
                    chkBoxValue.Hide();
                    dtpValue.Show();
                    btnGenerateGuid.Hide();
                    break;
                case TestParameterDataType.Bool:

                    tbValue.Hide();
                    chkBoxValue.Show();
                    dtpValue.Hide();
                    btnGenerateGuid.Hide();
                    break;
                default:
                    tbValue.Show();
                    chkBoxValue.Hide();
                    dtpValue.Hide();
                    btnGenerateGuid.Hide();
                    break;

            }
        }

        private void LbOptimisedParametersOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbOptimisedParameters.SelectedItem != null)
            {
                TestParameter testParameter = (TestParameter)lbOptimisedParameters.SelectedItem;
                currentTest.OptimisedStoredProcedureParameters.Remove(testParameter);
                logHelper.Log($"Removed: {testParameter}");
            }
        }

        private void LbUnoptimisedParametersOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lbUnoptimisedParameters.SelectedItem != null)
            {
                TestParameter testParameter = (TestParameter)lbUnoptimisedParameters.SelectedItem;
                currentTest.UnoptimisedStoredProcedureParameters.Remove(testParameter);
                logHelper.Log($"Removed: {testParameter}");
            }
        }

        private void LogsOnListChanged(object sender, ListChangedEventArgs e)
        {
            lblStatus.Text = $"Status: {logHelper.logs.Last().Value}";
        }

        private void SetupControls()
        {
            lbStatus.DataSource = logHelper.logs;
            cbType.DataSource = Enum.GetValues(typeof(TestParameterDataType));
            lbUnoptimisedParameters.DataSource = currentTest.UnoptimisedStoredProcedureParameters;
            lbOptimisedParameters.DataSource = currentTest.OptimisedStoredProcedureParameters;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnGenerate_Click(object sender, EventArgs e)
        {
            if (!isTestValid())
            {
                return;
            }
            logHelper.Log("Started generation");
            currentTest.UnoptimisedStoredProcedureName = tbUnoptimisedSPName.Text;
            currentTest.OptimisedStoredProcedureName = tbOptimisedSPName.Text;

            BuildSql();
            logHelper.Log("Generated SQL - It's been added to your clipboard");
            // RunSql();
        }

        private bool isTestValid()
        {
            if (string.IsNullOrWhiteSpace(tbOptimisedSPName.Text) || string.IsNullOrWhiteSpace(tbOptimisedSPName.Text))
            {
                IsNotValid("Stored Procedure Name");
                return false;
            }

            return true;
        }

        private async Task BuildSql()
        {
            StringBuilder stringBuilder = StoredProcedureTesterConsts.GetTemplate();

            FillVariables(ref stringBuilder);

            tbOutput.Text = stringBuilder.ToString();
            Clipboard.SetText(stringBuilder.ToString());
            await Task.Run(() =>
                {
                    btnGenerate.BackColor = Color.LightGreen;
                    Thread.Sleep(2000);
                    btnGenerate.BackColor = DefaultBackColor;
                });
        }

        private void FillVariables(ref StringBuilder stringBuilder)
        {
            stringBuilder.Replace("{UnoptimisedStoredProcedureName}", currentTest.UnoptimisedStoredProcedureName);
            stringBuilder.Replace("{OptimisedStoredProcedureName}", currentTest.OptimisedStoredProcedureName);

            StringBuilder unOptimisedParameters = new StringBuilder();
            for (int i = 0; i < currentTest.UnoptimisedStoredProcedureParameters.Count; i++)
            {
                TestParameter testParameter = currentTest.UnoptimisedStoredProcedureParameters[i];

                if (i == 0)
                {
                    unOptimisedParameters.AppendLine($"+N' {testParameter.GetSqlString()}'");
                }
                else
                {
                    unOptimisedParameters.AppendLine($"+N', {testParameter.GetSqlString()}'");
                }
            }

            StringBuilder optimisedParameters = new StringBuilder();
            for (int i = 0; i < currentTest.OptimisedStoredProcedureParameters.Count; i++)
            {
                TestParameter testParameter = currentTest.OptimisedStoredProcedureParameters[i];

                if (i == 0)
                {
                    optimisedParameters.AppendLine($"+N' {testParameter.GetSqlString()}'");
                }
                else
                {
                    optimisedParameters.AppendLine($"+N', {testParameter.GetSqlString()}'");
                }
            }

            stringBuilder.Replace("{UsingUnoptimisedParameters}", unOptimisedParameters.ToString());
            stringBuilder.Replace("{UsingOptimisedParameters}", optimisedParameters.ToString());

        }

        private void RunSql()
        {
            string queryString = @"

";
            string connectionString = "SERVER=(local);DATABASE=VCBedrock;Integrated Security=true";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                //command.Parameters.AddWithValue("@tPatSName", "Your-Parm-Value");
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        //TODO: ASHR006 - This needs updating eventually to run the sql thats built.
                        Console.WriteLine(String.Format("{0}, {1}",
                            reader["tPatCulIntPatIDPk"], reader["tPatSFirstname"]));// etc
                    }
                }

                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

            throw new NotImplementedException();
        }

        private void BtnAddToUnoptimised_Click(object sender, EventArgs e)
        {
            AddParameter(ParameterType.Unoptimised);
        }

        private void AddParameter(ParameterType parameterType)
        {
            if (!isParameterValid())
            {
                return;
            }

            TestParameter testParameter;
            TestParameterDataType dataType = (TestParameterDataType) cbType.SelectedItem;

            if (dataType == TestParameterDataType.DateTime)
            {
                testParameter = new TestParameter(tbName.Text, dtpValue.Value.ToString("MM/dd/yy hh:mm"), (TestParameterDataType)cbType.SelectedValue);
            }
            else
            {
                testParameter = new TestParameter(tbName.Text, tbValue.Text, (TestParameterDataType)cbType.SelectedValue);
            }

            switch (parameterType)
            {
                case ParameterType.Unoptimised:
                    currentTest.UnoptimisedStoredProcedureParameters.Add(testParameter);
                    logHelper.Log($"Added: {testParameter} to unoptimised");
                    break;
                case ParameterType.Optimised:
                    currentTest.OptimisedStoredProcedureParameters.Add(testParameter);
                    logHelper.Log($"Added: {testParameter} to optimised");
                    break;
                case ParameterType.Optimised | ParameterType.Unoptimised:
                    currentTest.UnoptimisedStoredProcedureParameters.Add(testParameter);
                    currentTest.OptimisedStoredProcedureParameters.Add(testParameter);
                    logHelper.Log($"Added: {testParameter} to both");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameterType), parameterType, null);
            }
        }

        private bool isParameterValid()
        {
            bool isValid = true;
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                isValid = false;
                IsNotValid("Name");
            }

            TestParameterDataType dataType = (TestParameterDataType)cbType.SelectedItem;

            if (dataType != null)
            {
                switch (dataType)
                {
                    case TestParameterDataType.DateTime:
                        if (string.IsNullOrWhiteSpace(dtpValue.Text))
                        {
                            isValid = false;
                            IsNotValid("Date Time Picker Value");
                        }
                        break;
                    case TestParameterDataType.Bool:
                        break;
                    default:
                        if (string.IsNullOrWhiteSpace(tbValue.Text))
                        {
                            isValid = false;
                            IsNotValid("Value");
                        }
                        break;
                }
            }
            return isValid;
        }

        private async Task IsNotValid(string fieldName)
        {
            logHelper.Log($"{fieldName} is required");

            await  Task.Run(() =>
            {
                 btnGenerate.BackColor = Color.LightCoral;
                 Thread.Sleep(1000);
                 btnGenerate.BackColor = DefaultBackColor;
            });
        }

        private void BtnAddToOptimised_Click(object sender, EventArgs e)
        {
            AddParameter(ParameterType.Optimised);
        }

        private void BtnAddToBoth_Click(object sender, EventArgs e)
        {
            AddParameter((ParameterType)3);
        }

        private void BtnGenerateGuid_Click(object sender, EventArgs e)
        {
            tbValue.Text = Guid.NewGuid().ToString();
        }

        private void TabPage1_Click(object sender, EventArgs e)
        {

        }
    }

    public class StoredProcedureTest
    {
        public string UnoptimisedStoredProcedureName { get; set; }
        public string OptimisedStoredProcedureName { get; set; }
        public BindingList<TestParameter> UnoptimisedStoredProcedureParameters { get; set; }
        public BindingList<TestParameter> OptimisedStoredProcedureParameters { get; set; }

        public StoredProcedureTest()
        {
            UnoptimisedStoredProcedureParameters = new BindingList<TestParameter>();
            OptimisedStoredProcedureParameters = new BindingList<TestParameter>();
        }

        public static StoredProcedureTest Default()
        {
            StoredProcedureTest test = new StoredProcedureTest();
            test.UnoptimisedStoredProcedureName = "VCBedrock.dbo.Test";
            test.OptimisedStoredProcedureName = "VCBedrock.dbo.TestOptimised";

            test.UnoptimisedStoredProcedureParameters.Add(TestParameter.Default());
            test.OptimisedStoredProcedureParameters.Add(TestParameter.Default());

            return test;
        }
    }

    public class TestParameter
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public TestParameterDataType Type { get; set; }

        public override string ToString()
        {
            return $"@{Name}='{Value}' : {Type}";
        }

        public static TestParameter Default()
        {
            TestParameter testParameter = new TestParameter("Id", "1", 0);
            return testParameter;
        }

        public TestParameter(string name, string value, TestParameterDataType type)
        {
            Name = name;
            Value = value;
            Type = type;
        }

        public string GetSqlString()
        {
            string result = string.Empty;

            switch (Type)
            {
                case TestParameterDataType.Guid:
                    result = $"@{Name} =\"' + CAST('{Value}' AS NVARCHAR(MAX)) + N'\"";
                    break;
                case TestParameterDataType.DateTime:
                    result = $"@{Name} =\"' + CAST('{Value}' AS NVARCHAR(MAX)) + N'\"";
                    //Todo: ASHR006 - Check what format DateTime needs to be in.
                    break;
                default:
                    result = $"@{Name} =' + CAST('{Value}' AS NVARCHAR(MAX)) + N'";
                    break;
            }

            return result;
        }
    }

    public enum TestParameterDataType
    {
        Int,
        String,
        Guid,
        DateTime,
        Bool,
        Custom
    }

    [Flags]
    public enum ParameterType
    {
        Unoptimised = 1,
        Optimised = 2,
    }
}

