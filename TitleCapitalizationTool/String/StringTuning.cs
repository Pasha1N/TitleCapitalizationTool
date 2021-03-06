﻿using System.Text;

namespace TitleCapitalizationTool.String
{
    internal class StringTuning
    {
        public string RemovingExtraSpaces(string stringForCorrection)
        {
            StringBuilder correctableString = new StringBuilder(stringForCorrection);

            for (int i = 0; i < correctableString.Length; i++)
            {
                if (i == correctableString.Length - 1)
                {
                    if (char.IsWhiteSpace(correctableString[i]))
                    {
                        correctableString.Remove(i, 1);
                    }
                }
                else
                {
                    if (char.IsWhiteSpace(correctableString[i]) && char.IsWhiteSpace(correctableString[i + 1]))
                    {
                        correctableString.Remove(i, 1);
                        i--;
                    }
                }
            }
            return correctableString.ToString();
        }

        public string PunctuationCorrection(string stringForCorrection)
        {
            StringBuilder correctableString = new StringBuilder(stringForCorrection);

            for (int i = 0; i < correctableString.Length; i++)
            {
                if (char.IsLetter(correctableString[i]) || correctableString[i] == '-')
                {
                    break;
                }
                else
                {
                    correctableString.Remove(i, 1);
                    i--;
                }
            }

            for (int i = 0; i < correctableString.Length; i++)
            {
                if (i < correctableString.Length - 1)
                {
                    if (char.IsWhiteSpace(correctableString[i]) && char.IsPunctuation(correctableString[i + 1]))
                    {
                        correctableString.Remove(i, 1);
                        if (i < 2)
                        {
                            i = 2;
                        }
                        i -= 2;
                    }
                    if (char.IsPunctuation(correctableString[i]) && char.IsLetter(correctableString[i + 1]))
                    {
                        correctableString.Insert(i + 1, " ");
                    }
                }
            }

            for (int i = 0; i < correctableString.Length - 1; i++)
            {
                if (i > 0)
                {
                    char.IsLetter(correctableString[i]);
                    char.IsLetter(correctableString[i - 1]);

                    if (correctableString[i] == '-' && !char.IsWhiteSpace(correctableString[i - 1]))
                    {
                        correctableString.Insert(i, " ");
                        i++;
                    }
                    if (correctableString[i] == '-' && !char.IsWhiteSpace(correctableString[i + 1]))
                    {
                        correctableString.Insert(i + 1, " ");
                    }
                }
            }
            return correctableString.ToString();
        }

        public string RegisterNormalization(string stringForCorrection)
        {
            stringForCorrection = stringForCorrection.ToLower();
            StringBuilder correctableString = new StringBuilder(stringForCorrection);

            int count = 0;
            for (int i = correctableString.Length - 1; i >= 0; i--)//переводит первые буквы всех слов в верхний регистр
            {
                if (i > 0)
                {
                    if (char.IsLetter(correctableString[i]))
                    {
                        count++;
                    }
                    else
                    {
                        if (count >= 2 && !char.IsLetter(correctableString[i]))
                        {
                            correctableString[i + 1] = char.ToUpper(correctableString[i + 1]);
                        }
                    }
                }
             
                if (!char.IsLetter(correctableString[i]))
                {
                    count = 0;
                }
            }
            stringForCorrection = correctableString.ToString();

            string[] exceptions = new string[] { " A", " An", " And", " At", " But", " By", " For", " In", " Nor", " Of", " On", " Or", " Out", " To", " The", " Up", " Yet" };

            for (int i = 0; i < exceptions.Length; i++)
            {
                for (int j = 0; j < stringForCorrection.Length; j++)
                {
                    int index = stringForCorrection.IndexOf(exceptions[i], j);

                    if (index >= 0)
                    {
                        j = 0;
                        j = index + exceptions[i].Length;
                        if (j <= stringForCorrection.Length - exceptions[i].Length)
                        {
                            if (!char.IsLetter(correctableString[j]))
                            {
                                correctableString[index + 1] = char.ToLower(correctableString[index + 1]);
                            }
                            j--;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
      
            for (int i = 0; i < correctableString.Length; i++)//переводит первую букву в верхний регистр
            {
                if (char.IsLetter(correctableString[i]))
                {
                    correctableString[i] = char.ToUpper(correctableString[i]);
                    break;
                }
            }

            return correctableString.ToString();
        }
    }
}