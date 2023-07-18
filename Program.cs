static class Program
{
    public static List<int[]> initCells = new List<int[]>
    {
        // Acorn.
        // new int[] {125, 127},
        // new int[] {126, 129},
        // new int[] {127, 126},
        // new int[] {127, 127},
        // new int[] {127, 130},
        // new int[] {127, 131},
        // new int[] {127, 132},

        // new int[] {117, 160},
        // new int[] {118, 160},
        // new int[] {118, 161},
        // new int[] {118, 158},
        // new int[] {119, 160},
        // new int[] {119, 158},
        // new int[] {120, 158},
        // new int[] {121, 156},
        // new int[] {122, 156},
        // new int[] {122, 154},

        // new int[] {130, 122},
        // new int[] {130, 123},
        // new int[] {130, 124},
        // new int[] {130, 125},
        // new int[] {130, 126},
        // new int[] {130, 127},
        // new int[] {130, 128},
        // new int[] {130, 129},

        // new int[] {130, 131},
        // new int[] {130, 132},
        // new int[] {130, 133},
        // new int[] {130, 134},
        // new int[] {130, 135},

        // new int[] {130, 139},
        // new int[] {130, 140},
        // new int[] {130, 141},

        // new int[] {130, 148},
        // new int[] {130, 149},
        // new int[] {130, 150},
        // new int[] {130, 151},
        // new int[] {130, 152},
        // new int[] {130, 153},
        // new int[] {130, 154},

        // new int[] {130, 156},
        // new int[] {130, 157},
        // new int[] {130, 158},
        // new int[] {130, 159},
        // new int[] {130, 160},
    };

    static void Main(string[] args)
    {
        Engine.Initialize(initCells);
    }
}