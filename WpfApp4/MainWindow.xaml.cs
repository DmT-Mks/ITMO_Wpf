using System.Windows.Controls;

namespace WpfApp4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Конвертер валют

        private void DollarToRubSum_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DollarToRubSum == null)
                return;

            if (DollarRate.Text == string.Empty || DollarSum.Text == string.Empty)
            {
                DollarToRubSum.Text = string.Empty;
            }

            var hasRateDollar = double.TryParse(DollarRate.Text, out var _);
            var hasDollarSum = double.TryParse(DollarSum.Text, out var _);

            if (!hasRateDollar || !hasDollarSum)
                return;

            var dollarRate = double.Parse(DollarRate.Text);
            var dollarSum = double.Parse(DollarSum.Text);

            var dollarToRubSum = dollarSum * dollarRate;
            DollarToRubSum.Text = dollarToRubSum.ToString();
        }

        private void EuroToRubSum_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (EuroToRubSum == null)
                return;

            if (EuroRate.Text == string.Empty || EuroSum.Text == string.Empty)
            {
                EuroToRubSum.Text = string.Empty;
            }

            var hasRateEuro = double.TryParse(EuroRate.Text, out var _);
            var hasEuroSum = double.TryParse(EuroSum.Text, out var _);

            if (!hasRateEuro || !hasEuroSum)
                return;

            var euroRate = double.Parse(EuroRate.Text);
            var euroSum = double.Parse(EuroSum.Text);

            var euroToRubSum = euroSum * euroRate;
            EuroToRubSum.Text = euroToRubSum.ToString();
        }

        private void GrivnaToRubSum_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (GrivnaToRubSum == null)
                return;

            if (GrivnaRate.Text == string.Empty || GrivnaSum.Text == string.Empty)
            {
                GrivnaToRubSum.Text = string.Empty;
            }

            var hasRateGrivna = double.TryParse(GrivnaRate.Text, out var _);
            var hasGrivnaSum = double.TryParse(GrivnaSum.Text, out var _);

            if (!hasRateGrivna || !hasGrivnaSum)
                return;

            var grivnaRate = double.Parse(GrivnaRate.Text);
            var grivnaSum = double.Parse(GrivnaSum.Text);

            var grivnaToRubSum = grivnaSum * grivnaRate;
            GrivnaToRubSum.Text = grivnaToRubSum.ToString();
        }

        private void DramaToRubSum_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (DramaToRubSum == null)
                return;

            if (DramaRate.Text == string.Empty || DramaSum.Text == string.Empty)
            {
                DramaToRubSum.Text = string.Empty;
            }

            var hasRateDrama = double.TryParse(DramaRate.Text, out var _);
            var hasDramaSum = double.TryParse(DramaSum.Text, out var _);

            if (!hasRateDrama || !hasDramaSum)
                return;

            var dramaRate = double.Parse(DramaRate.Text);
            var dramaSum = double.Parse(DramaSum.Text);

            var dramaToRubSum = dramaSum * dramaRate;
            DramaToRubSum.Text = dramaToRubSum.ToString();
        }

        #endregion

        #region Конвертер расстояния

        private const double InchesToMCoef = 0.0254;
        private const double FeetToMCoef = 0.3048;
        private const double MilesToMCoef = 1609.344;
        private const double VerstsToMCoef = 1066.8;
        
        private void InchesToMLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (InchesToMLength == null)
                return;

            if (InchesLength.Text == string.Empty)
            {
                InchesToMLength.Text = string.Empty;
            }

            var hasInchesLength = double.TryParse(InchesLength.Text, out var _);

            if (!hasInchesLength)
                return;

            var inchesLength = double.Parse(InchesLength.Text);

            var inchesToMLength = inchesLength * InchesToMCoef;
            InchesToMLength.Text = inchesToMLength.ToString();
        }
        
        private void FeetToMLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (FeetToMLength == null)
                return;

            if (FeetLength.Text == string.Empty)
            {
                FeetToMLength.Text = string.Empty;
            }

            var hasFeetLength = double.TryParse(FeetLength.Text, out var _);

            if (!hasFeetLength)
                return;

            var feetLength = double.Parse(FeetLength.Text);

            var feetToMLength = feetLength * FeetToMCoef;
            FeetToMLength.Text = feetToMLength.ToString();
        }
        
        private void MilesToMLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (MilesToMLength == null)
                return;

            if (MilesLength.Text == string.Empty)
            {
                MilesToMLength.Text = string.Empty;
            }

            var hasMilesLength = double.TryParse(MilesLength.Text, out var _);

            if (!hasMilesLength)
                return;

            var milesLength = double.Parse(MilesLength.Text);

            var milesToMLength = milesLength * MilesToMCoef;
            MilesToMLength.Text = milesToMLength.ToString();
        }
        
        private void VerstsToMLength_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (VerstsToMLength == null)
                return;

            if (VerstsLength.Text == string.Empty)
            {
                VerstsToMLength.Text = string.Empty;
            }

            var hasVerstsLength = double.TryParse(VerstsLength.Text, out var _);

            if (!hasVerstsLength)
                return;

            var verstsLength = double.Parse(VerstsLength.Text);

            var verstsToMLength = verstsLength * VerstsToMCoef;
            VerstsToMLength.Text = verstsToMLength.ToString();
        }

        #endregion
    }
}