namespace Enemy
{
    using System;

    public class Wolf : Enemy
    {
        public string[,] wolfImage = new string[,] 
        {
            {"                                 ..     "},
            {"                              ......    "},
            {"                            ..........  "},
            {"                           ............ "},
            {"                           ..........   "},
            {"                     ...............    "},
            {"            .......................     "},
            {"          .........................     "},
            {"          ........................      "},
            {"         ........................       "},
            {"        .........................       "},
            {"       ...........     ..........       "},
            {"      ...........          .....        "},
            {"     ...........           .....        "},
            {"    ...  ...  ...           ....        "},
            {"  ...     ..   ..           ....        "},
            {"          ..    ...          ....       "},
            {"           ...   ...          .....     "},
 
        };
        public override int HitPoints
        {
            get
            {
                return HitPoints;
            }
            set
            {
                HitPoints = 8; //The number is just for example.
            }
        }

        public Wolf(int hP, int aP, int dP) 
            : base(hP, aP, dP)
        {
        }

        public void DrawWolf()
        {
            for (int row = 0; row < wolfImage.Length; row++)
            {
                for (int col = 0; col < wolfImage.Length; col++)
                {
                    Console.Write(wolfImage[row, col]);
                }
            }
        }
    }
}
