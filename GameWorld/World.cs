using System;
using System.Collections.Generic;
//xlen between 0 and 40 , yLen between 0 and 100 px
public class World
{
    const int distance=10; //the distance between objects
    private int xLen;
    private int yLen;//Dimension of the world   
    private List<Place> places;
    enum form { EmptySpace, Enemy, Shop, Wall };

    public World(int xLen, int yLen, List<Place> places)
    {
        if((this.xLen>40)||(this.xLen<0))
        {
            this.xLen = 40;
        }else{
            this.xLen = xLen;
        }
       if((this.yLen>100)||(this.yLen<0))
        {
           this.yLen=100;
       }else{
           this.yLen = yLen;
       }
        //Test if the object is  out of world margins
       foreach (var item in places)
       {
           if ((item.XTopLeftPos > xLen) || (item.YTopLeftPos > yLen))
           {
               throw new ArgumentException("Top left corner out of World margins");
           }
           if((item.XLen+item.XTopLeftPos)>xLen)
           {
               throw new ArgumentException("Dimension X for this Place is ot of World margins");
           }
           if ((item.YLen + item.YTopLeftPos) > yLen)
           {
               throw new ArgumentException("Dimension Y for this Place is ot of World margins");
           }
       }
       this.places = places;
        
    }
    public int XLen
    {
        get
        {
            return this.xLen;
        }
    }
    public int YLen
    {
        get
        {
            return this.yLen;
        }
    }

    public void DrawPlaces()
    {
        foreach (var item in places)
        {
            item.Draw();
        }
        Console.SetCursorPosition(1, 1);
    }

}

