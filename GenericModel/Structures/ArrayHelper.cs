namespace GenericModel.Structures
{
    public static class ArrayHelper
    {
        public static int[,] Arr2D_DoubleToInt(double[,] arr2D)
        {
            int[,] intArr2D = new int[arr2D.GetLength(0), arr2D.GetLength(1)];

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    intArr2D[i, j] = (int)arr2D[i, j];
                }
            }

            return intArr2D;
        }

        public static string WriteInt2DToCSV(string fileName, int[,] arr2D)
        {
            string str = "";

            for (int i = 0; i < arr2D.GetLength(0); i++)
            {
                for (int j = 0; j < arr2D.GetLength(1); j++)
                {
                    if (j != 0)
                    {
                        str += ",";
                    }

                    str += arr2D[i, j];
                }
                str += "\r\n";
            }
            str += "\r\n";

            return str;
        }
    }
}
