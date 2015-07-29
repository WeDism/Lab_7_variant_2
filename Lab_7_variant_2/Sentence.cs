using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab_7_variant_2
{
    class Sentence
    {
        string data;
        char[] dataChar;
        int countData;
        int words = 0;
        int[,] positionSentence;
        int[,] positionWord;
        public Sentence(string data)
        {
            this.data = data;
            countData = CountData();
            positionSentence = PositionSentence();
            dataChar = StringToChar();
            words = CountWord();
            positionWord = PositionWord();
        }
        char[] StringToChar()
        {
            return data.ToCharArray();
        }
        string CharToString(char[] array)
        {
            string s = new string(array);
            return s;
        }
        public int Count
        {
            get
            {
                return countData;
            }
        }
        int CountData()
        {
            int value = 0;
            char[] mass = StringToChar();
            for (int index = 0; index < data.Length; index++)
            {
                if (char.IsUpper(data, index))
                {
                    for (index++; index < data.Length; index++)
                        if (mass[index] == '.')
                        {
                            value++;
                            break;
                        }
                }
            }
            return value;
        }
        int[,] PositionSentence()
        {
            int[,] matrix = new int[Count, 2];
            int index = 0;
            for (int i = 0; i < Count; i++)
            {
                bool flag = false;
                for (; index < data.Length; index++)
                {
                    char[] mass = StringToChar();
                    if (char.IsUpper(data, index))
                    {
                        int indexUpper = index;
                        for (index++; index < data.Length; index++)
                            if (mass[index] == '.')
                            {
                                matrix[i, 0] = indexUpper;
                                matrix[i, 1] = index + 1;
                                flag = true;
                                break;
                            }
                    }
                    if (flag) break;
                }
            }
            return matrix;
        }
        public void OutPutAllPosition()
        {
            for (int i = 0; i < Count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Console.Write(positionSentence[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        int EndSentence(int numberSentence)
        {
            return positionSentence[numberSentence, 1];
        }
        int StartSentence(int numberSentence)
        {
            return positionSentence[numberSentence, 0];
        }
        public string ReturnSentence(int numberSentence)
        {
            int sizeSentence = EndSentence(numberSentence) - StartSentence(numberSentence);
            char[] sequence = new char[sizeSentence];
            int i = StartSentence(numberSentence);
            for (int index = 0; index < sizeSentence; index++)
            {
                while (i < EndSentence(numberSentence))
                {
                    sequence[index] = dataChar[i];
                    break;
                }
                i++;
            }
            return CharToString(sequence);
        }
        int CountWord()
        {
            for (int index = 0; index < dataChar.Length; index++)
            {
                if (dataChar[index] == ' ')
                {
                    while (dataChar[index] != ' ')
                    {
                        index++;
                    }
                    words++;
                }
            }
            return words;
        }
        int[,] PositionWord()
        {
            int[,] matrix = new int[CountWords, 2];
            int index = 0;
            for (int i = 0; i < CountWords; i++)
            {
                bool flag = false;
                for (; index < dataChar.Length; index++)
                {
                    if (dataChar[index] != ' ')
                    {
                        int indexNotSpace = index;
                        for (index++; index < dataChar.Length; index++)
                            if (dataChar[index] == ' ')
                            {
                                while (dataChar[index] != ' ')
                                {
                                    index++;
                                }
                                matrix[i, 0] = indexNotSpace;
                                matrix[i, 1] = index;
                                flag = true;
                                break;
                            }
                        if (dataChar[index - 1] == '.')
                        {
                            matrix[i, 0] = indexNotSpace;
                            matrix[i, 1] = index - 1;
                            flag = true;
                            break;
                        }
                        if (dataChar[index - 1] == ',')
                        {
                            matrix[i, 0] = indexNotSpace;
                            matrix[i, 1] = index - 1;
                            flag = true;
                            break;
                        }
                        if (dataChar[index - 1] == ':')
                        {
                            matrix[i, 0] = indexNotSpace;
                            matrix[i, 1] = index - 1;
                            flag = true;
                            break;
                        }
                        if (dataChar[index - 1] == ';')
                        {
                            matrix[i, 0] = indexNotSpace;
                            matrix[i, 1] = index - 1;
                            flag = true;
                            break;
                        }
                    }
                    if (flag) break;
                }
            }
            return matrix;
        }
        public string ReturnWordString(int numberWord)
        {
            return CharToString(ReturnWord(numberWord));
        }
        char[] ReturnWord(int numberWord)
        {
            int sizeWord = EndWord(numberWord) - StartWord(numberWord);
            char[] word = new char[sizeWord];
            int i = StartWord(numberWord);
            for (int index = 0; index < sizeWord; index++)
            {
                while (i < EndWord(numberWord))
                {
                    word[index] = dataChar[i];
                    break;
                }
                i++;
            }
            return word;
        }
        public int CountWords
        {
            get
            {
                return words - 1;
            }
        }
        int EndWord(int numberWord)
        {
            return positionWord[numberWord, 1];
        }
        int StartWord(int numberWord)
        {
            return positionWord[numberWord, 0];
        }
        bool ComparisonChar(char[] wordInData, char[] wordData)
        {
            bool comparison = false;
            if (wordInData.Length == wordData.Length)
            {
                for (int index = 0; index < wordInData.Length; index++)
                {
                    char inData = wordInData[index], Data = wordData[index];
                    if (char.ToLower(inData) == char.ToLower(Data))
                        comparison = true;
                    else
                    {
                        comparison = false;
                        break;
                    }
                }
            }
            return comparison;
        }
        int EndWordSentence(int indexSentence)
        {
            int endNumberSentence = 0;

            return endNumberSentence;
        }
        int SeachNumberEnd(int positionEndSentence)
        {
            int numberWord = 0;
            for (int i = 0; i < CountWords; i++)
            {
                if (positionWord[i, 1] == positionEndSentence - 1)
                    numberWord = i;
            }
            return numberWord;
        }
        public string OutputSentence(char[] wordInData)
        {
            string s = "";
            int indexSentense = 0;
            for (int indexWord = 0; indexWord < CountWords; indexWord++)
            {
                char[] word = ReturnWord(indexWord);
                if (ComparisonChar(wordInData, word))
                {
                    for (; indexSentense < Count; indexSentense++)
                    {
                        if ((StartWord(indexWord) >= StartSentence(indexSentense)) && (EndWord(indexWord) <= EndSentence(indexSentense)))
                        {
                            indexWord = SeachNumberEnd(EndSentence(indexSentense)); // Start indexWord to end Sentence
                            s += ReturnSentence(indexSentense) + "\n";
                            break;
                        }
                    }
                }
            }
            return s;
        }
    }
}
