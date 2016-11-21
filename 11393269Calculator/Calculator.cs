using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorProgram
{
    class Calculator
    {
        private List<string> calcList = new List<string>();

        public Calculator()
        {}

        public void Calculate(string calculationInput)
        {
            LoadList(calculationInput);
            CalculateDivideMultiplyModulus();
            CalculateAddSubtract();
            PrintList();
        }

        private void CalculateDivideMultiplyModulus()
        {
            int previousInt, nextInt, result = 0;
            string currentStr;

            for (int i = 0; i < calcList.Count; i++)
            {
                currentStr = calcList.ElementAt(i);

                if (isDivideMultiplyModulus(currentStr))
                {
                    previousInt = Int32.Parse(calcList.ElementAt(i - 1));
                    nextInt = Int32.Parse(calcList.ElementAt(i + 1));

                    if (isMultiply(currentStr))
                        result = checked(previousInt * nextInt);
                    else if (isDivide(currentStr))
                        result = checked(previousInt / nextInt);
                    else if (isModulus(currentStr))
                        result = checked(previousInt % nextInt);

                    AddResultToList(i, result);
                    i--;
                }
            }
        }

        private void CalculateAddSubtract()
        {
            int previousInt, nextInt, result = 0;
            string currentStr;

            for (int i = 0; i < calcList.Count; i++)
            {
                currentStr = calcList.ElementAt(i);

                if (isAddSubtract(currentStr))
                {
                    previousInt = Int32.Parse(calcList.ElementAt(i - 1));
                    nextInt = Int32.Parse(calcList.ElementAt(i + 1));

                    if (isAdd(currentStr))
                        result = checked(previousInt + nextInt);
                    else if (isSubtract(currentStr))
                        result = checked(previousInt - nextInt);

                    AddResultToList(i, result);
                    i--;
                }
            }
        }

        private void LoadList(string calculationInput)
        {
            string tempString = "";

            for (int i = 0; i < calculationInput.Length; i++)
            {
                string character = calculationInput.ElementAt(i) + "";

                if (tempString == "" || !isOperator(character))
                {
                    tempString += character;
                }
                else
                {
                    calcList.Add(tempString);
                    tempString = "";
                    calcList.Add("" + character);
                }
            }
            // Final List.Add to add last string to list
            calcList.Add(tempString);
        }

        private void AddResultToList(int index, int result)
        {
            calcList.RemoveAt(index);
            calcList.Insert(index, result.ToString());
            calcList.RemoveAt(index + 1);
            calcList.RemoveAt(index - 1);
        }

        private void PrintList()
        {
            foreach (string str in calcList)
                Console.Write(str);
        }

        private bool isOperator(string inputString)
        {
            return isDivideMultiplyModulus(inputString) || isAddSubtract(inputString);
        }

        private bool isDivideMultiplyModulus(string inputString)
        {
            return isDivide(inputString) || isMultiply(inputString) || isModulus(inputString);
        }

        private bool isAddSubtract(string inputString)
        {
            return isAdd(inputString) || isSubtract(inputString);
        }

        private bool isDivide(string inputString)
        {
            return inputString == "/";
        }

        private bool isMultiply(string inputString)
        {
            return inputString == "*";
        }

        private bool isModulus(string inputString)
        {
            return inputString == "%";
        }

        private bool isAdd(string inputString)
        {
            return inputString == "+";
        }

        private bool isSubtract(string inputString)
        {
            return inputString == "-";
        }

    }
}
