
namespace Domain
{
    public class Generator
    {
        public static int CantorPairFunction(int n1, int n2)
        {
            int k1, k2;
            if (n1 < n2)
            {
                k1 = n1;
                k2 = n1;
            }
            else
            {
                k1 = n2;
                k2 = n1;
            }
            return (((k1 + k2) * (k1 + k2 + 1)) / 2) + k2;
        }
    }
}
