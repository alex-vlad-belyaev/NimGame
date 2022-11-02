namespace BundlesEngine
{
    public class GameTriplex
    {
        private int _a;
        private int _b;
        private int _c;

        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public bool MakeStepW(GameTriplex[] triplexes)
        {
            int n = 1;

            while (n <= A + B + C)
            {
                if (n <= A)
                {
                    _a = A - n;
                    _b = B;
                    _c = C;
                }
                else if (n > A + B)
                {
                    _a = A;
                    _b = B;
                    _c = A + B + C - n;
                }
                else
                {
                    _a = A;
                    _b = A + B - n;
                    _c = C;
                }
                int l = 0;
                while (l < triplexes.Length)
                {
                    GameTriplex tr = new GameTriplex(_a, _b, _c);
                    if (tr.MakeStep(triplexes, l)) l = triplexes.Length + 1;
                    else l++;
                }

                if (l == triplexes.Length)
                {
                    n = A + B + C + 1;
                    A = _a;
                    B = _b;
                    C = _c;
                    return true;
                }
                n++;
            }
            return false;
        }

        public bool MakeStep(GameTriplex[] triplexes, int k)
        {

            int n = 1;

            while (n <= A + B + C)

            {
                if (n <= A)
                {
                    _a = A - n;
                    _b = B;
                    _c = C;

                    var presult = Order(_a, _b, _c);
                    _a = presult.a;
                    _b = presult.b;
                    _c = presult.c;

                    if (triplexes[k].A == _a & triplexes[k].B == _b & triplexes[k].C == _c)
                    {
                        A = A - n;
                        return true;
                    }
                    else n++;
                }
                else if (n > A + B)
                {
                    _a = A;
                    _b = B;
                    _c = A + B + C - n;

                    var presult = Order(_a, _b, _c);
                    _a = presult.a;
                    _b = presult.b;
                    _c = presult.c;

                    if (triplexes[k].A == _a & triplexes[k].B == _b & triplexes[k].C == _c)
                    {
                        C = A + B + C - n;
                        return true;
                    }
                    else n++;
                }
                else
                {
                    _a = A;
                    _b = A + B - n;
                    _c = C;

                    var presult = Order(_a, _b, _c);
                    _a = presult.a;
                    _b = presult.b;
                    _c = presult.c;

                    if (triplexes[k].A == _a & triplexes[k].B == _b & triplexes[k].C == _c)
                    {
                        B = A + B - n;
                        return true;
                    }
                    else n++;
                }
            }

            return false;
        }

        public void Print()
        {
            Console.WriteLine($"A: {A}, B: {B}, C: {C}");
        }

        public GameTriplex(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void OrderABC()
        {
            var orderedABC = Order(A, B, C);
            A = orderedABC.a;
            B = orderedABC.b;
            C = orderedABC.c;
        }

        private (int a, int b, int c) Order(int a, int b, int c)
        {
            int d, i = 0;
            while (i < 3)
            {
                if (a > b)
                {
                    d = b;
                    b = a;
                    a = d;
                }

                i++;

                if (b > c)
                {
                    d = c;
                    c = b;
                    b = d;
                }

                i++;
            }

            return (a, b, c);
        }
    }
}