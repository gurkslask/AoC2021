
namespace mainlib{
public class coords{
        // top : 
        // tr
        // tl
        // mid
        // br
        // bl
        // bot
        //
        public Dictionary<string, string> coords_dict = new Dictionary<string, string>();
        public Dictionary<string, int> number_dict = new ();

        public string toString(){
                return String.Join("\n",
                        from pair in coords_dict
                        select pair.ToString());
        }
        
        public void print(){
                Console.WriteLine( String.Join("\n",
                        from pair in coords_dict
                        select pair.ToString()));
        }
        public string printNums(){
                string result = "";
                foreach (string keyOutput in number_dict.Keys){
                         result += ($"Number: {number_dict[keyOutput]}, pattern: {keyOutput} \n");
                }
                return result;
        }

        public Dictionary<string, string> find_num_1(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                if (pattern.Length == 2)
                {
                    //Console.WriteLine($"This is number one: {pattern}");
                    this.coords_dict["tr"] = pattern;
                    this.coords_dict["br"] = pattern;
                    this.number_dict[String.Concat(pattern.OrderBy(c => c))] = 1;
                }
            }
            return coords_dict;
        }

        public Dictionary<string, string> find_num_7(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                if (pattern.Length == 3)
                {
                    string ts = pattern;
                    //Console.WriteLine($"This is number seven: {pattern}");
                    //Console.WriteLine($"Tar bort från sträng {ts}, ta bort char: {coords_dict["tr"][0]}");
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][0]);
                    //Console.WriteLine($"Tar bort från sträng {ts}, ta bort char: {coords_dict["tr"][1]}");
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][1]);
                    coords_dict["top"] = ts;
                    number_dict[String.Concat(pattern.OrderBy(c => c))] = 7;
                }
            }
            return coords_dict;
        }
        public Dictionary<string, string> find_num_4(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                if (pattern.Length == 4)
                {
                    string ts = pattern;
                    //Console.WriteLine($"This is number four: {pattern}");
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][1]);
                    // ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][1]);
                    coords_dict["tl"] = ts;
                    coords_dict["mid"] = ts;
                    //Console.WriteLine($"Dicten: {coords_dict}");
                    number_dict[String.Concat(pattern.OrderBy(c => c))] = 4;
                }
            }
            return coords_dict;
        }
        public Dictionary<string, string> find_num_9(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                if (pattern.Length == 6 && 
                    pattern.Contains(coords_dict["tl"][0]) &&
                    pattern.Contains(coords_dict["tl"][1]) &&
                    pattern.Contains(coords_dict["top"][0]) &&
                    pattern.Contains(coords_dict["tr"][0]) &&
                    pattern.Contains(coords_dict["tr"][1]) )
                {
                    string ts = pattern;
                    //Console.WriteLine($"This is number nine: {pattern}");
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tl"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["top"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][0]);

                    // Om en av dessa char finns i "tr", ta bort den
                    foreach(char cc in ts){
                            if (coords_dict["tr"].Contains(cc)){
                                    ts = mainlib.Class1.removeChar(ts, cc);
                            }
                    }

                    // Om en av dessa char finns i "tr", ta bort den
                    foreach(char cc in ts){
                            if (coords_dict["mid"].Contains(cc)){
                                    ts = mainlib.Class1.removeChar(ts, cc);
                            }
                    }

                    number_dict[String.Concat(pattern.OrderBy(c => c))] = 9;
                    coords_dict["bot"] = ts;
                }
            }
            return coords_dict;
        }
        public Dictionary<string, string> find_num_6(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                // En kommentar
                if (pattern.Length == 6 && 
                    coords_dict["tr"].Length == 2
                   ) { if ( pattern.Contains(coords_dict["tr"][0]) ^
                            pattern.Contains(coords_dict["tr"][1]) )

                        {
                            string ts = pattern;
                            char nollan = coords_dict["tr"][0];
                            char ettan = coords_dict["tr"][1];
                            ////Console.WriteLine($"This is number six: {pattern}");

                            // Om denna finns så är denna på tr, och den andra på br
                            if (pattern.Contains(coords_dict["tr"][0]))
                            {
                                    coords_dict["br"] = coords_dict["tr"][0].ToString();
                                    coords_dict["tr"] = coords_dict["tr"][1].ToString();
                            } else {
                                    coords_dict["br"] = coords_dict["tr"][1].ToString();
                                    coords_dict["tr"] = coords_dict["tr"][0].ToString();
                            }

                            ts = mainlib.Class1.removeChar(ts, coords_dict["tl"][0]);
                            ts = mainlib.Class1.removeChar(ts, coords_dict["tl"][1]);
                            ts = mainlib.Class1.removeChar(ts, coords_dict["top"][0]);
                            //Console.WriteLine($"Ska försöka ta bort {nollan} från {ts}");
                            ts = mainlib.Class1.removeChar(ts, nollan);
                            ts = mainlib.Class1.removeChar(ts, ettan);
                            ts = mainlib.Class1.removeChar(ts, coords_dict["bot"][0]);
                            number_dict[String.Concat(pattern.OrderBy(c => c))] = 6;
                            //Console.WriteLine($"Detta återstår av sexxa pattern {ts}");
                            coords_dict["bl"] = ts;
                        }
                }
            }
            return coords_dict;
        }

        public Dictionary<string, string> find_num_3(mainlib.Class1.cords input)
        {
            foreach (string pattern in input.signalPatterns)
            {
                if (pattern.Length == 5 && 
                    pattern.Contains(coords_dict["top"][0]) &&
                    pattern.Contains(coords_dict["tr"][0]) &&
                    pattern.Contains(coords_dict["br"][0]) &&
                    pattern.Contains(coords_dict["bot"][0]) &&
                    (
                    pattern.Contains(coords_dict["mid"][0]) ||
                    pattern.Contains(coords_dict["mid"][1])
                    )
                    )


                {
                    string ts = pattern;
                    //Console.WriteLine($"This is number three: {pattern}");
                    ts = mainlib.Class1.removeChar(ts, coords_dict["br"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["top"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["tr"][0]);
                    ts = mainlib.Class1.removeChar(ts, coords_dict["bot"][0]);

                    number_dict[String.Concat(pattern.OrderBy(c => c))] = 3;
                    coords_dict["mid"] = ts;
                    coords_dict["tl"] = mainlib.Class1.removeChar(coords_dict["tl"], coords_dict["mid"][0]);
                }
            }
            return coords_dict;
        }
        public void find_num_8(mainlib.Class1.cords input){
                foreach (string pattern in input.signalPatterns)
                {
                        if (pattern.Length == 7)
                        {
                            number_dict[String.Concat(pattern.OrderBy(c => c))] = 8;
                        }
                }
        }
        //1346789
        //25
        public void find_num_2(mainlib.Class1.cords input){
                foreach (string pattern in input.signalPatterns)
                {
                        if (pattern.Length == 5 &&
                        pattern.Contains(coords_dict["top"][0]) &&
                        pattern.Contains(coords_dict["tr"][0]) &&
                        pattern.Contains(coords_dict["bl"][0]) &&
                        pattern.Contains(coords_dict["bot"][0]) &&
                        pattern.Contains(coords_dict["mid"][0]) 
                        )
                        {
                            number_dict[String.Concat(pattern.OrderBy(c => c))] = 2;
                        } 
                }
        }
        public void find_num_5(mainlib.Class1.cords input){
                foreach (string pattern in input.signalPatterns)
                {
                        if (pattern.Length == 5 &&
                        pattern.Contains(coords_dict["top"]) &&
                        pattern.Contains(coords_dict["tl"]) &&
                        pattern.Contains(coords_dict["br"]) &&
                        pattern.Contains(coords_dict["bot"]) &&
                        pattern.Contains(coords_dict["mid"]) 

                        )
                        {
                            number_dict[String.Concat(pattern.OrderBy(c => c))] = 5;
                        }
                }
        }
        public void find_num_0(mainlib.Class1.cords input){
                foreach (string pattern in input.signalPatterns)
                {
                        if (pattern.Length == 6 &&
                        pattern.Contains(coords_dict["top"]) &&
                        pattern.Contains(coords_dict["tl"]) &&
                        pattern.Contains(coords_dict["br"]) &&
                        pattern.Contains(coords_dict["bot"]) &&
                        pattern.Contains(coords_dict["bl"]) &&
                        pattern.Contains(coords_dict["tr"]) 

                        )
                        {
                            number_dict[String.Concat(pattern.OrderBy(c => c))] = 0;
                        }
                }
        }
    }
}
