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
        private StringBuilder stringBuilder;
        private LogHelper logHelper;
        private KonamiSequence sequence = new KonamiSequence();

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
            this.KeyPreview = true;
            this.KeyUp += Form1_KeyUp;
            dtpValue.Hide();
            chkBoxValue.Hide();
            btnGenerateGuid.Hide();
            HideResults();
        }

        private void HideResults()
        {
            foreach (Control tabPage5Control in tabPage5.Controls)
            {
                tabPage5Control.Hide();
            }

            lNoResults.Show();
        }

        private void ShowResults()
        {
            foreach (Control tabPage5Control in tabPage5.Controls)
            {
                tabPage5Control.Show();
            }
            lNoResults.Hide();
            lException.Hide();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (sequence.IsCompletedBy(e.KeyCode))
            {
                EasterEgg easterEgg = new EasterEgg();
                easterEgg.Show();
            }
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
            logHelper.Log("Generated SQL");
            RunSql();
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
            stringBuilder = StoredProcedureTesterConsts.GetTemplate();

            FillVariables(ref stringBuilder);

            tbOutput.Text = stringBuilder.ToString();
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
            try
            {
            string queryString = stringBuilder.ToString();
            string connectionString = "SERVER=(local);DATABASE=VCBedrock;Integrated Security=true";

            foreach (string startupScript in StoredProcedureTesterConsts.StartupScripts)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(startupScript, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                }
            }

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
                        TestSummary testSummary = new TestSummary();
                        testSummary.FirstTestResult = new TestResult((bool) reader["First Test Result"],
                            reader["First Test Message"] == DBNull.Value
                                ? string.Empty
                                : (string) reader["First Test Message"]);
                        testSummary.SecondTestResult = new TestResult((bool) reader["Second Test Result"],
                            reader["Second Test Message"] == DBNull.Value
                                ? string.Empty
                                : (string) reader["Second Test Message"]);
                        testSummary.ThirdTestResult = new TestResult((bool) reader["Third Test Result"],
                            reader["Third Test Message"] == DBNull.Value
                                ? string.Empty
                                : (string) reader["Third Test Message"]);
                        testSummary.FourthTestResult = new TestResult((bool) reader["Fourth Test Result"],
                            reader["Fourth Test Message"] == DBNull.Value
                                ? string.Empty
                                : (string) reader["Fourth Test Message"]);
                        testSummary.OverallResult = (bool) reader["Overall Result"];
                        testSummary.UnoptimisedDateTimeStart = (DateTime) reader["Unoptimised Start"];
                        testSummary.UnoptimisedDateTimeEnd = (DateTime) reader["Unoptimised End"];
                        testSummary.OptimisedDateTimeStart = (DateTime) reader["Optimised Start"];
                        testSummary.OptimisedDateTimeEnd = (DateTime) reader["Optimised End"];

                        //Results
                        lFirst.Text =
                            $"1st Test (Same number of rows returned): {testSummary.FirstTestResult.Result.GetResultString()}";
                        lSecond.Text =
                            $"2nd Test (Same number of columns returned): {testSummary.SecondTestResult.Result.GetResultString()}";
                        lThird.Text =
                            $"3rd Test (Same columns returned): {testSummary.ThirdTestResult.Result.GetResultString()}";
                        lFourth.Text =
                            $"4th Test (Same data returned): {testSummary.FourthTestResult.Result.GetResultString()}";
                        lOverall.Text = $"Overall Result: {testSummary.OverallResult.GetResultString()}";

                        //Message
                        l1st.Text = $"1st Test: {testSummary.FirstTestResult.Message}";
                        l2nd.Text = $"2nd Test: {testSummary.SecondTestResult.Message}";
                        l3rd.Text = $"3rd Test: {testSummary.ThirdTestResult.Message}";
                        l4th.Text = $"4th Test: {testSummary.FourthTestResult.Message}";

                        //Performance
                        lUnoptimisedTotalTime.Text =
                            $"Unoptimised Total Time (ms): {testSummary.UnoptimisedTotalTime.ToString()}";
                        lOptimisedTotalTime.Text =
                            $"Optimised Total Time (ms): {testSummary.OptimisedTotalTime.ToString()}";
                        lDifference.Text = $"Difference (ms):{testSummary.DifferenceTotalTime.ToString()}";
                        lDifferencePercent.Text = $"Difference (%): {testSummary.DifferencePercentage.ToString()}";

                        lDateTimeRun.Text = $"Date Time Run: {DateTime.Now.ToString("dd/MM/yy hh:mm:ss")}";
                        Clipboard.SetText(lDateTimeRun.Text);

                        logHelper.Log("Ran SQL");
                        if (testSummary.OverallResult)
                        {
                            logHelper.Log("Test PASSED");
                            tabPage5.BackColor = Color.LightGreen;
                        }
                        else
                        {
                            logHelper.Log("Test FAILED");
                            tabPage5.BackColor = Color.LightCoral;
                        }
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
                ShowResults();
                tabControl1.SelectedIndex = 1;
            }
            }
            catch (Exception ex)
            {
                TestFailed(ex.Message);
            }
        }

        private void TestFailed(string message)
        {
            HideResults();
            logHelper.Log(message);
            tabPage5.BackColor = Color.LightCoral;
            lException.Show();
            lException.Text = message;
            tabControl1.SelectedIndex = 1;
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

        private void BtnRunAgain_Click(object sender, EventArgs e)
        {
            RunSql();
        }

        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbOutput.Text);
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

    public class TestSummary
    {
        public TestResult FirstTestResult { get; set; }
        public TestResult SecondTestResult { get; set; }
        public TestResult ThirdTestResult { get; set; }
        public TestResult FourthTestResult { get; set; }
        public bool OverallResult { get; set; }
        public DateTime UnoptimisedDateTimeStart { get; set; }
        public DateTime UnoptimisedDateTimeEnd { get; set; }
        public DateTime OptimisedDateTimeStart { get; set; }
        public DateTime OptimisedDateTimeEnd { get; set; }

        public double UnoptimisedTotalTime {
            get
            {
                TimeSpan span = UnoptimisedDateTimeEnd - UnoptimisedDateTimeStart;
                return span.Milliseconds;
            }
        }
        public double OptimisedTotalTime
        {
            get
            {
                TimeSpan span = OptimisedDateTimeEnd - OptimisedDateTimeStart;
                return span.Milliseconds;
            }
        }
        public double DifferenceTotalTime
        {
            get
            {
                return UnoptimisedTotalTime - OptimisedTotalTime;
            }
        }
        public double DifferencePercentage
        {
            get { return (OptimisedTotalTime / UnoptimisedTotalTime) * 100; }
        }
    }

    public class TestResult
    {
        public bool Result { get; set; }
        public string Message { get; set; }

        public TestResult(bool result, string message)
        {
            Result = result;
            Message = message;
        }
    }

    public static class ExtensionMethods
    {
        public static string GetResultString(this bool boolean)
        {
            if (boolean)
            {
                return "PASS";
            }
            else
            {
                return "FAIL";
            }
        }
    }

    public class KonamiSequence
    {

        List<Keys> Keys = new List<Keys>{System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.Up,
            System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.Down,
            System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right,
            System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.Right,
            System.Windows.Forms.Keys.B, System.Windows.Forms.Keys.A};
        private int mPosition = -1;

        public int Position
        {
            get { return mPosition; }
            private set { mPosition = value; }
        }

        public bool IsCompletedBy(Keys key)
        {

            if (Keys[Position + 1] == key)
            {
                // move to next
                Position++;
            }
            else if (Position == 1 && key == System.Windows.Forms.Keys.Up)
            {
                // stay where we are
            }
            else if (Keys[0] == key)
            {
                // restart at 1st
                Position = 0;
            }
            else
            {
                // no match in sequence
                Position = -1;
            }

            if (Position == Keys.Count - 1)
            {
                Position = -1;
                return true;
            }

            return false;
        }
    }
}


