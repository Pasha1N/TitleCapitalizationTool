namespace TitleCapitalizationTool.String 
{
    internal class StringCorrection
    {
        private StringTuning stringTuning = new StringTuning(); 
        private string correctableString;

        public StringCorrection()
        {
        }
        
        public StringCorrection(string stringForCorrection)
        {
            correctableString = stringForCorrection;
        }

        public void SetString(string stringForCorrection)
        {
            correctableString = stringForCorrection;
        }

        public string Correction()
        {
            correctableString = stringTuning.RemovingExtraSpaces(correctableString);
            correctableString = stringTuning.RegisterNormalization(correctableString);
            correctableString = stringTuning.PunctuationCorrection(correctableString);

            return correctableString;
        }
    }
}