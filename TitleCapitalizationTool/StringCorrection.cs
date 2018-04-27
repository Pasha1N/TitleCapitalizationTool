﻿namespace TitleCapitalizationTool.String 
{
    internal class StringCorrection
    {
        private StringTuning stringTuning = new StringTuning(); 
        private string correctableString;

        public StringCorrection(){ }

        public StringCorrection(string stringForCorrection)
        {
            correctableString = stringForCorrection;
        }

        public void SetString(string stringForCorrection)
        {
            correctableString = null;
            correctableString = stringForCorrection;
        }

        public string StringCorrectioN()
        {
            correctableString = stringTuning.RemovingExtraSpaces(correctableString);
            correctableString = stringTuning.PunctuationCorrection(correctableString);
            correctableString = stringTuning.RegisterNormalization(correctableString);
            return correctableString;
        }
    }
}