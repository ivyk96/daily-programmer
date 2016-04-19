﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace TicTactToe
{
    public class GameFactory
    {
        private int turn = 0;
        private int xWins = 0;
        private int oWins = 0;

        public string GetTurn()
        {
            if (turn == 0)
                return "X";
            else
                return "O";
        }

        public string ResetTurn()
        {
            turn = 0;
            return GetTurn();
        }

        public string PlayTurn(Button b)
        {
            if(turn == 0)
            {
                b.Text = "X";
                turn++;
            }
            else
            {
                b.Text = "O";
                turn--;
            }

            b.Enabled = false;
            return GetTurn();
        }

        private void DisableButtons(List<Button> buttonList)
        {
            foreach(Button b in buttonList)
            {
                b.Enabled = false;
            }
        }

        public string CheckWinner(IEnumerable<Button> buttonList)
        {
            List<Button> list = buttonList.ToList();
            list.RemoveAt(0);
            list.Reverse();
            string winner = "";

            //Horizontal checks
            // X
            if (list[0].Text == "X" && list[1].Text == "X" && list[2].Text == "X")
                winner = "X wins!";
            else if (list[3].Text == "X" && list[4].Text == "X" && list[5].Text == "X")
                winner = "X wins!";
            else if (list[6].Text == "X" && list[7].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[1].Text == "O" && list[2].Text == "O")
                winner = "O wins!";
            else if (list[3].Text == "O" && list[4].Text == "O" && list[5].Text == "O")
                winner = "O wins!";
            else if (list[6].Text == "O" && list[7].Text == "O" && list[8].Text == "O")
                winner = "O wins!";

            //Vertical checks
            // X
            if (list[0].Text == "X" && list[3].Text == "X" && list[6].Text == "X")
                winner = "X wins!";
            else if (list[1].Text == "X" && list[4].Text == "X" && list[7].Text == "X")
                winner = "X wins!";
            else if (list[2].Text == "X" && list[5].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[3].Text == "O" && list[6].Text == "O")
                winner = "O wins!";
            else if (list[1].Text == "O" && list[4].Text == "O" && list[7].Text == "O")
                winner = "O wins!";
            else if (list[2].Text == "O" && list[5].Text == "O" && list[8].Text == "O")
                winner = "O wins!";

            //Diagonal checks
            // X
            if (list[0].Text == "X" && list[4].Text == "X" && list[8].Text == "X")
                winner = "X wins!";
            else if (list[2].Text == "X" && list[4].Text == "X" && list[6].Text == "X")
                winner = "X wins!";
            // O
            else if (list[0].Text == "O" && list[4].Text == "O" && list[8].Text == "O")
                winner = "O wins!";
            else if (list[2].Text == "O" && list[4].Text == "O" && list[6].Text == "O")
                winner = "O wins!";

            if (winner == "X wins!")
                xWins++;
            else
                oWins++;

            if (winner != string.Empty)
                DisableButtons(list);

            return winner;
        }
    }
}