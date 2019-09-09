using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using StoredProcedureTester.Enums;
using StoredProcedureTester.ExtensionMethods;
using StoredProcedureTester.Helpers;
using StoredProcedureTester.Interfaces;
using StoredProcedureTester.Models;
using StoredProcedureTester.Runners;

namespace StoredProcedureTester
{
    public partial class StoredProcedureTester : Form
    {
        private StoredProcedureTest currentTest;
        private KonamiSequence sequence = new KonamiSequence();
        private ILogHelper logHelper;
        private ISqlTestRunner sqlTestRunner;
        private IParameterManager parameterManager;

        public StoredProcedureTester()
        {
            InitializeComponent();
            SetupDefaults();
            SetupControls();
            sqlTestRunner = new SqlTestRunner(logHelper);
            parameterManager = new ParameterManager(logHelper, currentTest);
        }

        private void SetupDefaults()
        {
            currentTest = new StoredProcedureTest();
            logHelper = new LogHelper();
            logHelper.GetLogs().ListChanged += LogsOnListChanged;
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

        private void CheckEasterEgg(KeyEventArgs e)
        {
            if (sequence.IsCompletedBy(e.KeyCode))
            {
                EasterEgg easterEgg = new EasterEgg();
                easterEgg.Show();
            }
        }

        private void UpdateUIForValues()
        {
            TestParameterDataType dataType = (TestParameterDataType)cbType.SelectedItem;

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
        private void RemoveOptimisedParameter()
        {
            if (lbOptimisedParameters.SelectedItem != null)
            {
                TestParameter testParameter = (TestParameter)lbOptimisedParameters.SelectedItem;
                parameterManager.RemoveParameter(testParameter, ParameterType.Optimised);
                //currentTest.OptimisedStoredProcedureParameters.Remove(testParameter);
                //logHelper.Log($"Removed: {testParameter}");
            }
        }

        private void RemoveUnoptimisedParameter()
        {
            if (lbUnoptimisedParameters.SelectedItem != null)
            {
                TestParameter testParameter = (TestParameter)lbUnoptimisedParameters.SelectedItem;
                parameterManager.RemoveParameter(testParameter, ParameterType.Unoptimised);
                //currentTest.UnoptimisedStoredProcedureParameters.Remove(testParameter);
                //logHelper.Log($"Removed: {testParameter}");
            }
        }

        private async Task RunTest()
        {
            if (!isTestValid())
            {
                return;
            }

            logHelper.Log("Started generation");
            currentTest.DatabaseName = tbDBName.Text;
            currentTest.UnoptimisedStoredProcedureName = tbUnoptimisedSPName.Text;
            currentTest.OptimisedStoredProcedureName = tbOptimisedSPName.Text;

            try
            {
                TestSummary testSummary = await sqlTestRunner.Run(currentTest);
                tbOutput.Text = testSummary.Test.GeneratedSql;
                WriteResultsToUI(testSummary);
            }
            catch (Exception e)
            {
                UpdateUIForTestFailed(e.Message);
            }
        }

        private void WriteResultsToUI(TestSummary testSummary)
        {
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

            if (testSummary.OverallResult)
            {
                tabPage5.BackColor = Color.LightGreen;
            }
            else
            {
                tabPage5.BackColor = Color.LightCoral;
            }

            ShowResults();
            tabControl1.SelectedIndex = 1;
        }

        private void UpdateUIForTestFailed(string message)
        {
            HideResults();
            logHelper.Log(message);
            tabPage5.BackColor = Color.LightCoral;
            lException.Show();
            lException.Text = message;
            tabControl1.SelectedIndex = 1;
        }

        private bool isTestValid()
        {
            if (string.IsNullOrWhiteSpace(tbDBName.Text))
            {
                IsNotValid("Database Name");
                return false;
            }

            if (string.IsNullOrWhiteSpace(tbOptimisedSPName.Text) || string.IsNullOrWhiteSpace(tbOptimisedSPName.Text))
            {
                IsNotValid("Stored Procedure Name");
                return false;
            }

            return true;
        }

        private void SetupControls()
        {
            lbStatus.DataSource = logHelper.GetLogs();
            cbType.DataSource = Enum.GetValues(typeof(TestParameterDataType));
            lbUnoptimisedParameters.DataSource = currentTest.UnoptimisedStoredProcedureParameters;
            lbOptimisedParameters.DataSource = currentTest.OptimisedStoredProcedureParameters;
        }

        private void AddParameter(ParameterType parameterType)
        {
            if (!isParameterValid())
            {
                return;
            }

            TestParameterDataType dataType = (TestParameterDataType)cbType.SelectedItem;

            if (dataType == TestParameterDataType.DateTime)
            {
                parameterManager.AddParameter(tbName.Text, dtpValue.Value.ToString("MM /dd/yy hh:mm"), parameterType, dataType);
            }
            else if (dataType == TestParameterDataType.Bool)
            {
                parameterManager.AddParameter(tbName.Text, chkBoxValue.Text, parameterType, dataType);
            }
            else
            {
                parameterManager.AddParameter(tbName.Text, tbValue.Text, parameterType, dataType);
            }

            //TestParameter testParameter;
            //TestParameterDataType dataType = (TestParameterDataType)cbType.SelectedItem;

            //if (dataType == TestParameterDataType.DateTime)
            //{
            //    testParameter = new TestParameter(tbName.Text, dtpValue.Value.ToString("MM /dd/yy hh:mm"), (TestParameterDataType)cbType.SelectedValue);
            //}
            //else if (dataType == TestParameterDataType.Bool)
            //{
            //    testParameter = new TestParameter(tbName.Text, chkBoxValue.Text, (TestParameterDataType)cbType.SelectedValue);
            //}
            //else
            //{
            //    testParameter = new TestParameter(tbName.Text, tbValue.Text, (TestParameterDataType)cbType.SelectedValue);
            //}

            //switch (parameterType)
            //{
            //    case ParameterType.Unoptimised:
            //        currentTest.UnoptimisedStoredProcedureParameters.Add(testParameter);
            //        logHelper.Log($"Added: {testParameter} to unoptimised");
            //        break;
            //    case ParameterType.Optimised:
            //        currentTest.OptimisedStoredProcedureParameters.Add(testParameter);
            //        logHelper.Log($"Added: {testParameter} to optimised");
            //        break;
            //    case ParameterType.Optimised | ParameterType.Unoptimised:
            //        currentTest.UnoptimisedStoredProcedureParameters.Add(testParameter);
            //        currentTest.OptimisedStoredProcedureParameters.Add(testParameter);
            //        logHelper.Log($"Added: {testParameter} to both");
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException(nameof(parameterType), parameterType, null);
            //}
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

            await Task.Run(() =>
            {
                btnGenerate.BackColor = Color.LightCoral;
                Thread.Sleep(1000);
                btnGenerate.BackColor = DefaultBackColor;
            });
        }

        #region Controls
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            CheckEasterEgg(e);
        }

        private void CbTypeOnSelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUIForValues();
        }

        private void LbOptimisedParametersOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveOptimisedParameter();
        }

        private void LogsOnListChanged(object sender, ListChangedEventArgs e)
        {
            lblStatus.Text = $"Status: {logHelper.GetLogs().Last().Value}";
        }

        private void LbUnoptimisedParametersOnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            RemoveUnoptimisedParameter();
        }

        private async void BtnGenerate_Click(object sender, EventArgs e)
        {
            await RunTest();
        }

        private void BtnAddToUnoptimised_Click(object sender, EventArgs e)
        {
            AddParameter(ParameterType.Unoptimised);
        }

        private void BtnAddToOptimised_Click(object sender, EventArgs e)
        {
            //Todo: ASHR006 Create Parameter Manager
            AddParameter(ParameterType.Optimised);
        }

        private void BtnAddToBoth_Click(object sender, EventArgs e)
        {
            AddParameter(ParameterType.Optimised | ParameterType.Unoptimised);
        }

        private void BtnGenerateGuid_Click(object sender, EventArgs e)
        {
            tbValue.Text = Guid.NewGuid().ToString();
        }

        private async void BtnRunAgain_Click(object sender, EventArgs e)
        {
            await RunTest();
        }

        private void BtnCopyToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tbOutput.Text);
        }

        #endregion
    }
}


