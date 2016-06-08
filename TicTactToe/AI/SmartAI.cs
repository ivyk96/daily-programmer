﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTactToe
{
    public class SmartAI : AIFactory
    {
        private RandomAI ai = new RandomAI();
        private Random random = new Random();

        public SmartAI()
        {

        }

        public Button Turn(IEnumerable<Button> buttonList)
        {
            Button b = GetSmartTurn(MakeRowList(MakeList(buttonList)));

            if (b == null)
                b = GetDumbTurn(buttonList);

            if (b != null)
                return b;
            else
                return null;
        }

        private Button GetSmartTurn(List<Row> rowList)
        {
            foreach(Row row in rowList)
            {
                Button b = RowCheck(row, "O");

                if (b != null)
                    return b;
            }

            foreach(Row row in rowList)
            {
                Button b = RowCheck(row, "X");

                if (b != null)
                    return b;
            }

            return null;
        }

        private Button GetDumbTurn(IEnumerable<Button> buttonList)
        {
            List<Button> list = MakeList(buttonList);
            Button b = null;
            if (list[4].Text == "X")
            {
                List<Button> randomList = new List<Button>();
                for(int i = 0; i < list.Count; i++)
                {
                    if(list[i].Enabled == true && i % 2 == 0 && i != 4)
                    {
                        randomList.Add(list[i]);
                    }
                }

                if (randomList.Count != 0)
                    b = randomList[random.Next(0, randomList.Count)];
            }

            if (list[4].Enabled == true && b == null)
                b = list[4];
            else if(b == null)
                b = ai.Turn(buttonList);

            return b;
        }

        private Button RowCheck(Row row, string check)
        {
            int count = 0;
            
            foreach(Button b in row.Values)
            {
                if (b.Text == check)
                {
                    count++;
                }
            }

            if(count == 2)
            {
                foreach(Button b in row.Values)
                {
                    if (b.Text == "")
                        return b;
                }
            }

            return null;
        }

        private List<Row> MakeRowList(List<Button> list)
        {
            List<Row> rowList = new List<Row>();

            rowList.Add(new Row(list[0], list[1], list[2]));
            rowList.Add(new Row(list[3], list[4], list[5]));
            rowList.Add(new Row(list[6], list[7], list[8]));
            rowList.Add(new Row(list[0], list[3], list[6]));
            rowList.Add(new Row(list[1], list[4], list[7]));
            rowList.Add(new Row(list[2], list[5], list[8]));
            rowList.Add(new Row(list[0], list[4], list[8]));
            rowList.Add(new Row(list[2], list[4], list[6]));

            return rowList;
        }

        private List<Button> MakeList(IEnumerable<Button> buttonList)
        {
            List<Button> list = buttonList.ToList();
            list.RemoveAt(0);
            list.Reverse();
            return list;
        }
    }

    public class Row
    {
        public List<Button> Values = new List<Button>();

        public Row(Button b1, Button b2, Button b3)
        {
            Values.Add(b1);
            Values.Add(b2);
            Values.Add(b3);
        }
    }
}