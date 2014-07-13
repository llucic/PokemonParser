using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace Pokemon_Parser
{
    public partial class Form1 : Form
    {
        private int[] dexStarts = { 1, 152, 252, 387, 494, 650, 719 };
        private int[] megas = { 3, 6, 9, 65, 94, 115, 127, 130, 142, 150, 
                              181, 212, 214, 229, 248,
                              257, 282, 303, 306, 308, 310, 354, 359, 
                              445, 448, 
                              460};

        private string[] types = {"bug", "dark", "dragon", "electric", "fairy", "fighting", "fire", "flying", "ghost",
                                 "grass", "ground", "ice", "normal", "poison", "psychict", "rock", "steel", "water"};

        public Form1()
        {
            InitializeComponent();
        }

        #region Event Handlers

        private void btn_ParseOne_Click(object sender, EventArgs e)
        {
            int DexNumber = Convert.ToInt32(txt_DexNumber.Text);
            int GenNumber = 6;
            if (DexNumber < dexStarts[5]) GenNumber = 5;
            if (DexNumber < dexStarts[4]) GenNumber = 4;
            if (DexNumber < dexStarts[3]) GenNumber = 3;
            if (DexNumber < dexStarts[2]) GenNumber = 2;
            if (DexNumber < dexStarts[1]) GenNumber = 1;
            ParseSingle(GenNumber, DexNumber);
            MessageBox.Show("Done");
        }

        private void btn_ParseGen_Click(object sender, EventArgs e)
        {
            int GenNumber = Convert.ToInt32(txt_Generation.Text);
            int GenStart = dexStarts[GenNumber - 1];
            int GenEnd = dexStarts[GenNumber];
            

            for (int i = GenStart; i < GenEnd; i++)
            {
                this.Text = "Progress " + i + "/" + (GenEnd - 1);
                ParseSingle(GenNumber, i);
            }

            this.Text = "Pokemon Parser";
            MessageBox.Show("Done");
        }
        
        private void btn_ParseAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dexStarts.Length - 1; i++)
            {
                for (int j = dexStarts[i]; j < dexStarts[i + 1]; j++)
                {
                    this.Text = "Progress " + j + "/718";
                    ParseSingle(i + 1, j);
                }
            }

            this.Text = "Pokemon Parser";
            MessageBox.Show("Done");
        }

        private void btn_ParseItems_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://serebii.net/itemdex/list/holditem.shtml");

            Stream objStream;

            objStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string full = "";
            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                full += sline;
            }

            List<string> HoldItems = new List<string>();

            ParseItem(full, ref HoldItems);

            var json = new JavaScriptSerializer().Serialize(HoldItems);

            try
            {
                StreamWriter file = new StreamWriter("C:\\Users\\Luka\\Documents\\Parsed Pokemon Data\\Items.txt");

                file.WriteLine(json);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Done");
        }

        private void btn_ParseBerries_Click(object sender, EventArgs e)
        {
            WebRequest request = WebRequest.Create("http://serebii.net/itemdex/list/berry.shtml");

            Stream objStream;

            objStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string full = "";
            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                full += sline;
            }

            List<string> Berries = new List<string>();

            ParseItem(full, ref Berries);

            var json = new JavaScriptSerializer().Serialize(Berries);

            try
            {
                StreamWriter file = new StreamWriter("C:\\Users\\Luka\\Documents\\Parsed Pokemon Data\\Berries.txt");

                file.WriteLine(json);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Done");
        }

        private void btn_ParseTMs_Click(object sender, EventArgs e)
        {

        }

        private void btn_ParseAttacks_Click(object sender, EventArgs e)
        {
            List<Move> moves = new List<Move>();
            foreach (string type in types)
            {
                ParseMovesByType(type, ref moves);
            }

            var json = new JavaScriptSerializer().Serialize(moves);

            try
            {
                StreamWriter file = new StreamWriter("C:\\Users\\Luka\\Documents\\Parsed Pokemon Data\\Moves.txt");

                file.WriteLine(json);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            MessageBox.Show("Done");
        }

        private void btn_ParseAbilities_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Pokemon

        private void ParseSingle(int genNumber, int dexNumber)
        {
            string value = dexNumber + "";
            value = value.PadLeft(3, '0');
            WebRequest request = WebRequest.Create("http://www.serebii.net/pokedex-xy/" + value + ".shtml");
            
            Stream objStream;

            objStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string full = "";
            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                full += sline;
            }

            PokemonInfo pokemon = new PokemonInfo();

            ParseName(full, ref pokemon);
            ParsePokemonAbilities(full, ref pokemon);
            ParseLevelUpAttacks(full, ref pokemon);
            ParsePokemonTMs(full, ref pokemon);
            ParseEggMoves(full, ref pokemon);
            ParseTutorMoves(full, ref pokemon);
            ParseSpecialMoves(full, ref pokemon);
            ParsePreEvoMoves(full, ref pokemon);
            ParseTransferMoves(full, ref pokemon);
            ParseBaseStats(full, ref pokemon);

            var json = new JavaScriptSerializer().Serialize(pokemon);

            try
            {
                StreamWriter file = new StreamWriter("C:\\Users\\Luka\\Documents\\Parsed Pokemon Data\\" + genNumber + "\\" + value + ".txt");

                file.WriteLine(json);
                file.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            if (dexNumber == 6 || dexNumber == 150)
            {
                ParseMega(" X", value, genNumber, full);
                ParseMega(" Y", value, genNumber, full);
            } 
            else if (megas.Contains(dexNumber))
            {
                ParseMega("", value, genNumber, full);
            }
        }

        private void ParseName(string data, ref PokemonInfo output)
        {
            string[] temp = data.Split(new String[] { "<title>" }, StringSplitOptions.None);

            string[] temp2 = temp[1].Split(new String[] { " - " }, StringSplitOptions.None);

            String name = temp2[0];//.Split(new String[] { "</td>" }, StringSplitOptions.None)[0];

            //output += name + "\r\n";
            output.Name = name;
        }

        private void ParsePokemonAbilities(string data, ref PokemonInfo output)
        {
            //output += "\r\nAbilities:\r\n";
            string[] temp = data.Split(new String[] { "Abilities" }, StringSplitOptions.None);

            string[] temp2 = temp[1].Split(new String[] { "</tr>" }, StringSplitOptions.None);

            string[] temp3 = temp2[0].Split(new String[] { "<b>" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String abilityName = temp3[i].Split(new String[] { "</b>" }, StringSplitOptions.None)[0];
                if (i == temp3.Length - 1 && i != 1)
                {
                    output.HiddenAbility = abilityName;
                }
                else
                {
                    output.Abilities.Add(abilityName);
                }
                //output += abilityName + "\r\n";
            }
        }

        private void ParseLevelUpAttacks(string data, ref PokemonInfo output)
        {
            //output += "\r\nLevel Up:\r\n";
            string[] temp = data.Split(new String[] { "X / Y Level Up" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "TM & HM Attacks" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Egg Moves" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Move Tutor Attacks" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Special Moves" }, StringSplitOptions.None);
            } 

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Transfer" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.LevelUpMoves.Add(attackName);
            }
        }

        private void ParsePokemonTMs(string data, ref PokemonInfo output)
        {
            //output += "\r\nTMs & HMs:\r\n";
            string[] temp = data.Split(new String[] { "TM & HM Attacks" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "Egg Moves" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Move Tutor Attacks" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Special Moves" }, StringSplitOptions.None);
            } 
            
            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Transfer" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.TmMoves.Add(attackName);
            }
        }

        private void ParseEggMoves(string data, ref PokemonInfo output)
        {
            //output += "\r\nEgg Moves:\r\n";
            string[] temp = data.Split(new String[] { "Egg Moves" }, StringSplitOptions.None);

            if (temp.Length == 2)
            {
                return;
            }

            string[] temp2 = temp[2].Split(new String[] { "Move Tutor Attacks" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[2].Split(new String[] { "Special Moves" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[2].Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[2].Split(new String[] { "Transfer" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[2].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 2; i < temp3.Length; i++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.EggMoves.Add(attackName);

                if (attackName.Equals("Volt Tackle")) i++;
            }
        }

        private void ParseTutorMoves(string data, ref PokemonInfo output)
        {
            //output += "\r\nMove Tutor Moves\r\n";
            string[] temp = data.Split(new String[] { "Move Tutor Attacks" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Transfer" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.TutorMoves.Add(attackName);
            }

        }

        private void ParseSpecialMoves(string data, ref PokemonInfo output)
        {
            //output += "\r\nSpecial Moves\r\n";
            string[] temp = data.Split(new String[] { "Special Moves" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Transfer" }, StringSplitOptions.None);
            }

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.SpecialMoves.Add(attackName);
            }
        }

        private void ParsePreEvoMoves(string data, ref PokemonInfo output)
        {
            //output += "\r\nPre-Evolution Moves\r\n";
            string[] temp = data.Split(new String[] { "Pre-Evolution" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }
            
            string[] temp2 = temp[1].Split(new String[] { "Transfer" }, StringSplitOptions.None);

            if (temp2.Length == 1)
            {
                temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            }

            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i += 2)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.PreEvoMoves.Add(attackName);
            }
        }

        private void ParseTransferMoves(string data, ref PokemonInfo output)
        {
            //output += "\r\nTransfer Only Moves\r\n";
            string[] temp = data.Split(new String[] { "Transfer" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "Stats" }, StringSplitOptions.None);
            
            string[] temp3 = temp2[0].Split(new String[] { "shtml\">" }, StringSplitOptions.None);

            for (int i = 2; i < temp3.Length; i ++)
            {
                String attackName = temp3[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                //Console.WriteLine(attackName);
                //output += attackName + "\r\n";
                output.TransferMoves.Add(attackName);
            }

        }

        private void ParseBaseStats(string data, ref PokemonInfo output)
        {
            //output += "\r\nStats:\r\n";
            string[] temp = data.Split(new String[] { "Total:" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "</tr>" }, StringSplitOptions.None);

            string[] temp3 = temp2[0].Split(new String[] { "</td>" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length -1; i++)
            {
                String stat = temp3[i].Split(new String[] { "fooinfo\">" }, StringSplitOptions.None)[1];

                output.BaseStats.Add(stat);
            }
        }

        #endregion

        #region Mega Evolution

        private void ParseMega(string type, string value, int genNumber, string data)
        {
            MegaPokemonInfo pokemon = new MegaPokemonInfo();

            ParseMegaName(type, data, ref pokemon);
            ParseMegaAbility(type, data, ref pokemon);
            ParseMegaBaseStats(type, data, ref pokemon);

            var json = new JavaScriptSerializer().Serialize(pokemon);

            try
            {
                StreamWriter file = new StreamWriter("C:\\Users\\Luka\\Documents\\Parsed Pokemon Data\\" + genNumber + "\\" + value + " - Mega" + type + ".txt");

                file.WriteLine(json);
                file.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void ParseMegaName(string type, string data, ref MegaPokemonInfo output)
        {
            string[] temp = data.Split(new String[] { "<title>" }, StringSplitOptions.None);

            string[] temp2 = temp[1].Split(new String[] { " - " }, StringSplitOptions.None);

            String name = temp2[0];//.Split(new String[] { "</td>" }, StringSplitOptions.None)[0];

            //output += name + "\r\n";
            output.Name = "Mega " + name + type;
        }

        private void ParseMegaAbility(string type, string data, ref MegaPokemonInfo output)
        {
            //output += "\r\nAbilities:\r\n";
            string[] temp0 = data.Split(new String[] { "Mega Evolution" + type }, StringSplitOptions.None);

            string[] temp = temp0[1].Split(new String[] { "Abilities" }, StringSplitOptions.None);

            string[] temp2 = temp[1].Split(new String[] { "</tr>" }, StringSplitOptions.None);

            string[] temp3 = temp2[0].Split(new String[] { "<b>" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length; i++)
            {
                String abilityName = temp3[i].Split(new String[] { "</b>" }, StringSplitOptions.None)[0];
                output.Abilities.Add(abilityName);
                //output += abilityName + "\r\n";
            }
        }

        private void ParseMegaBaseStats(string type, string data, ref MegaPokemonInfo output)
        {
            if (!String.IsNullOrEmpty(type)) type = " " + type;
            //output += "\r\nStats:\r\n";
            string[] temp0 = data.Split(new String[] { "Mega Evolution" + type }, StringSplitOptions.None);

            string[] temp = temp0[1].Split(new String[] { "Total:" }, StringSplitOptions.None);

            if (temp.Length == 1)
            {
                return;
            }

            string[] temp2 = temp[1].Split(new String[] { "</tr>" }, StringSplitOptions.None);

            string[] temp3 = temp2[0].Split(new String[] { "</td>" }, StringSplitOptions.None);

            for (int i = 1; i < temp3.Length - 1; i++)
            {
                String stat = temp3[i].Split(new String[] { "fooinfo\">" }, StringSplitOptions.None)[1];

                output.BaseStats.Add(stat);
            }
        }

        #endregion

        #region Other

        private void ParseMovesByType(string type, ref List<Move> output)
        {
            WebRequest request = WebRequest.Create("http://serebii.net/attackdex-xy/" + type + ".shtml");

            Stream objStream;

            objStream = request.GetResponse().GetResponseStream();

            StreamReader objReader = new StreamReader(objStream);

            string full = "";
            string sline = "";

            while (sline != null)
            {
                sline = objReader.ReadLine();
                full += sline;
            }

            ParseMoves(full, ref output);
        }

        private void ParseItem(string data, ref List<string> output)
        {
            string[] temp = data.Split(new String[] { "Effect</td>" }, StringSplitOptions.None);

            string[] temp2 = temp[1].Split(new String[] { ".shtml\">" }, StringSplitOptions.None);

            for (int i = 2; i < temp2.Length; i++)
            {
                string itemName = temp2[i].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];
                if (String.IsNullOrEmpty(itemName) || itemName.Contains("<")) continue;
                output.Add(itemName);
            }
        }

        private void ParseAbilities(string data, ref List<string> output)
        {

        }

        private void ParseMoves(string data, ref List<Move> output)
        {
            //string[] temp = data.Split(new String[] { "</tr>" }, StringSplitOptions.None);
            string[] temp2 = data.Split(new String[] { "<tr>" }, StringSplitOptions.None);

            for (int i = 8; i < temp2.Length - 1; i++)
            {
                // parse the name
                string[] temp3 = temp2[i].Split(new String[] { "shtml\">" }, StringSplitOptions.None);
                string name = temp3[1].Split(new String[] { "</a>" }, StringSplitOptions.None)[0];

                // parse type and category
                temp3 = temp2[i].Split(new String[] { "type/" }, StringSplitOptions.None);
                string type = temp3[1].Split(new String[] { ".gif" }, StringSplitOptions.None)[0];
                string category = temp3[2].Split(new String[] { ".png" }, StringSplitOptions.None)[0];

                // parse power and accuracy
                temp3 = temp2[i].Split(new String[] { "cen\">" }, StringSplitOptions.None);
                string power = temp3[4].Split(new String[] { "</td>" }, StringSplitOptions.None)[0].Trim();
                string accuracy = temp3[5].Split(new String[] { "</td>" }, StringSplitOptions.None)[0].Trim();

                // parse description
                temp3 = temp2[i].Split(new String[] { "info\">" }, StringSplitOptions.None);
                string description = temp3[2].Split(new String[] { "</td>" }, StringSplitOptions.None)[0].Trim();

                int ipower, iaccuracy;
                if (power.CompareTo("--") == 0)
                {
                    ipower = -1;
                }
                else
                {
                    ipower = Convert.ToInt32(power);
                }

                if (accuracy.CompareTo("--") == 0)
                {
                    iaccuracy = -1;
                }
                else
                {
                    iaccuracy = Convert.ToInt32(accuracy);
                }

                Move m = new Move(name, type, category, ipower, iaccuracy, description);

                output.Add(m);
            }
        }

        private void ParseTMs(string data, ref List<string> output)
        {

        }

        #endregion

    }
}
