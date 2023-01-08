//  There were multiple layers of code on both sides of the coin, with a hidden message revealed after each layer was solved. 



level4_hex_text();
level3_inner_circular_text();
level2_outer_circular_text();

static void level4_hex_text() 
{
    Console.WriteLine("\nLevel 4: Hex text");

    var str = File.ReadAllText("hex_text.txt").Replace("\n","");
    //Console.WriteLine(str);
    //Console.WriteLine($"{str.Length}, {(double)str.Length/2} twos, {(double)str.Length/4} fours");

    //Split into pairs and make bytes
    var bytes = new byte[str.Length/2];
    for(int i = 0; i<str.Length;i=i+2)
    {
        var pair = str.Substring(i, 2);
        //Console.Write($"{pair} ");
        bytes[i/2] = Convert.ToByte(pair, 16);
    }

    var a = new []
    {
       //Convert.ToByte("75", 16)
       Convert.ToByte("A5", 16),
       Convert.ToByte("D7", 16),
       Convert.ToByte("5A", 16),
       Convert.ToByte("5d", 16),
       Convert.ToByte("75", 16),
    };


    //Console.WriteLine();

    //Console.WriteLine(string.Join(" ", a.Select( x => Convert.ToString(x,toBase: 2).PadLeft(8, '0'))));

    //int x= Convert.ToInt16("5d 75", 16);

    

 var xored = new byte[str.Length/2];
    for(int i = 0; i< bytes.Length; i++)
    {
        xored[i] = (byte)(bytes[i] ^ a[i % a.Length]);
    }

    //Console.WriteLine("\nXored:");

    //Console.WriteLine(string.Join(" ", xored));

    var s = System.Text.ASCIIEncoding.ASCII.GetString(xored);

    Console.WriteLine(s);

    // For 75 years the Australian Signals Directorate has brought 
    //together people with the skills, adaptability and imagination 
    // to operate in the slim area between the difficult and the impossible.
}

static void level3_inner_circular_text()
{
    Console.WriteLine("\nLevel 3: Inner circular text");
//
    var str = File.ReadAllText("inner_circular_text.txt").Replace("\n","");
    //Console.WriteLine(str);

    //Console.WriteLine();    
    for(int n = 0; n < 2; n++)
    //var n = 0;
    {
        for(int y = 0; y < 7; y++)
            for(int x = 0; x < 5; x++ )
             {
            var i = (7*5*n)+(x*7+y);
            //Console.Write(str[i]);
             }
        //Console.WriteLine();
    }
    Console.WriteLine("BELONGING TO A GREAT TEAM STRIVING FOR EXCELLENCE WE MAKE A DIFFERENCE XOR HEX A 5D 75");

    // A5D75 is surely 'ASD 75' (Australian Signals Directorate 75th anniverary)
    // but which to xor as there are 5 chars...I'll try the last 4 first
}

static void level2_outer_circular_text()
{
    Console.WriteLine("\nLevel 2: Outer circular text");
    var str = File.ReadAllText("outer_circular_text.txt");
    //Console.WriteLine(str);
        for(int x =0; x < str.Length; x++)
        {
            if(str[x] >= 'A' && str[x] <= 'Z')
            {
                var index = str[x] - 'A';

                //Console.Write((char)('Z'-index));
            }
            else
            {
                //Console.Write(str[x]);
            }
        }   
        //Console.WriteLine();
    Console.WriteLine("FIND CLARITY IN 7 WIDTH X 5 DEPTH * WE ARE AUDACIOUS IN CONCEPT AND METICULOUS IN EXECUTION *");
}