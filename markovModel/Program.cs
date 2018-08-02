using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace markovModel
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string s = "";

            s = File.ReadAllText("in.txt");
            //Console.WriteLine(s.Contains('\n'));
            s = s.ToLower();
            s = s.Replace("\n"," ");
            s = markov.utilities.clean(s, new char[] {' '});

            markov.model m = markov.utilities.textToModel(s, ' ');
            Console.WriteLine("Model with {0} unique states", m.states.Count);
            Console.WriteLine("'{0}' being the most popular state", m.states.First(y=>y.Value.transitions.Length == m.states.Max(x=>x.Value.transitions.Length)).Value.identifier);
            //m.currentState = m.states["the"];
            List<markov.state> states = m.genMaxTerm(1);
            states.Remove(m.terminatingState);
            string outp = "";
            for (int i = 0; i < states.Count; i++)
            {
                if (states[i].identifier.Equals(m.terminatingState)) continue;
                outp += (string)states[i].identifier;
                if (i < states.Count-1) outp += " ";
            }
            Console.WriteLine(outp);
        }
    }
}
