using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module6
{
    static class IntExtentions
    {
        public static int GetNegative(this int num)
        {
            if (num < 0)
            {
                return num;
            }
            else
            {
                return -num;
            }
        }

        public static int GetPositive(this int num)
        {
            if (num < 0)
            {
                return -num;
            }
            else
            {
                return num;
            }
        }
    }

    internal class OldCode
    {
        class IndexingClass
        {
            private int[] array;

            public IndexingClass(int[] array)
            {
                this.array = array;
            }

            public int this[int index]
            {
                get
                {
                    if (index >= 0 && index < array.Length)
                    {
                        return array[index];
                    }
                    else
                    {
                        return 0;
                    }
                }
                set
                {
                    if (index >= 0 && index < array.Length)
                    {
                        array[index] = value;
                    }
                }
            }
        }

        abstract class ComputerPart
        {
            public abstract void Work();
        }

        class Processor : ComputerPart
        {
            public override void Work()
            {
                Console.WriteLine("Processor is working");
            }
        }

        class GraphicCard : ComputerPart
        {
            public override void Work()
            {
                Console.WriteLine("GraphicCard is working");
            }
        }

        class MotherBoard : ComputerPart
        {
            public override void Work()
            {
                Console.WriteLine("MotherBoard is working");
            }
        }

        class Obj
        {
            public string Name;
            public string Description;

            public static string Parent;
            public static int DaysInWeek;
            public static int MaxValue;
            static Obj()
            {
                Parent = "System.Object";
                DaysInWeek = 7;
                MaxValue = 2000;
            }

        }




        class Helper
        {
            public static void Swap(ref int num1, ref int num2)
            {
                int temp = num2;
                num2 = num1;
                num1 = temp;
            }
        }
    }
}
