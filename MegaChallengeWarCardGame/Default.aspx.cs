using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeWarCardGame
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) resultLabel1.Text = "";
        }

        protected void playButton_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Shuffle(rnd, out Dictionary<int, string> deck, out List<KeyValuePair<int, string>> playerDeck1, out List<KeyValuePair<int, string>> playerDeck2);
            Game(playerDeck1, playerDeck2);
        }

        public int Shuffle(Random rnd, out Dictionary<int, string> deck, out List<KeyValuePair<int, string>> playerDeck1, out List<KeyValuePair<int, string>> playerDeck2)
        {

            deck = new Dictionary<int, string>();
            deck.Add(1, "2♠"); deck.Add(2, "3♠"); deck.Add(3, "4♠"); deck.Add(4, "5♠"); deck.Add(5, "6♠");
            deck.Add(6, "7♠"); deck.Add(7, "8♠"); deck.Add(8, "9♠"); deck.Add(9, "10♠"); deck.Add(10, "J♠");
            deck.Add(11, "Q♠"); deck.Add(12, "K♠"); deck.Add(13, "A♠");

            deck.Add(14, "<span style=\"color: red; \">2♥</span>"); deck.Add(15, "<span style=\"color: red; \">3♥</span>"); deck.Add(16, "<span style=\"color: red; \">4♥</span>"); deck.Add(17, "<span style=\"color: red; \">5♥</span>"); deck.Add(18, "<span style=\"color: red; \">6♥</span>");
            deck.Add(19, "<span style=\"color: red; \">7♥</span>"); deck.Add(20, "<span style=\"color: red; \">8♥</span>"); deck.Add(21, "<span style=\"color: red; \">9♥</span>"); deck.Add(22, "<span style=\"color: red; \">10♥</span>"); deck.Add(23, "<span style=\"color: red; \">J♥</span>");
            deck.Add(24, "<span style=\"color: red; \">Q♥</span>"); deck.Add(25, "<span style=\"color: red; \">K♥</span>"); deck.Add(26, "<span style=\"color: red; \">A♥</span>");

            deck.Add(27, "<span style=\"color: red; \">2♦</span>"); deck.Add(28, "<span style=\"color: red; \">3♦</span>"); deck.Add(29, "<span style=\"color: red; \">4♦</span>"); deck.Add(30, "<span style=\"color: red; \">5♦</span>"); deck.Add(31, "<span style=\"color: red; \">6♦</span>");
            deck.Add(32, "<span style=\"color: red; \">7♦</span>"); deck.Add(33, "<span style=\"color: red; \">8♦</span>"); deck.Add(34, "<span style=\"color: red; \">9♦</span>"); deck.Add(35, "<span style=\"color: red; \">10♦</span>"); deck.Add(36, "<span style=\"color: red; \">J♦</span>");
            deck.Add(37, "<span style=\"color: red; \">Q♦</span>"); deck.Add(38, "<span style=\"color: red; \">K♦</span>"); deck.Add(39, "<span style=\"color: red; \">A♦</span>");

            deck.Add(40, "2♣"); deck.Add(41, "3♣"); deck.Add(42, "4♣"); deck.Add(43, "5♣"); deck.Add(44, "6♣");
            deck.Add(45, "7♣"); deck.Add(46, "8♣"); deck.Add(47, "9♣"); deck.Add(48, "10♣"); deck.Add(49, "J♣");
            deck.Add(50, "Q♣"); deck.Add(51, "K♣"); deck.Add(52, "A♣");

            playerDeck1 = new List<KeyValuePair<int, string>>();
            playerDeck2 = new List<KeyValuePair<int, string>>();


            int iterationCount = 0;
            for (int i = 51; i >= 0; i--)
            {
                int index = rnd.Next(i);
                if (iterationCount % 2 == 0)
                {
                    playerDeck1.Add(new KeyValuePair<int, string>(deck.ElementAt(index).Key, deck.ElementAt(index).Value));
                    deck.Remove(deck.ElementAt(index).Key);
                    resultLabel1.Text += String.Format("Player One was dealt: {0}<br>", 
                        playerDeck1.ElementAt(iterationCount / 2).Value);
                }
                else
                {
                    playerDeck2.Add(new KeyValuePair<int, string>(deck.ElementAt(index).Key, deck.ElementAt(index).Value));
                    deck.Remove(deck.ElementAt(index).Key);
                    resultLabel1.Text += String.Format("Player Two was dealt: {0}<br>", 
                        playerDeck2.ElementAt((iterationCount - 1) / 2).Value);
                }

                iterationCount++;
            }

            return 0;
        }

        public int Game(List<KeyValuePair<int, string>> playerDeck1, List<KeyValuePair<int, string>> playerDeck2)
        {
            Dictionary<int, string> battlePile = new Dictionary<int, string>();

            for (int i = 20; i > 0; i--)
            {
                resultLabel1.Text += "<br><br>FIGHT!<br>______________________<br>";
                resultLabel1.Text += String.Format("Battle Card: {0} versus {1}!<br>", 
                    playerDeck1.ElementAt(0).Value, playerDeck2.ElementAt(0).Value);

                battlePile.Add(playerDeck1.ElementAt(0).Key, playerDeck1.ElementAt(0).Value);
                battlePile.Add(playerDeck2.ElementAt(0).Key, playerDeck2.ElementAt(0).Value);

                int cardValue1 = 0;
                int cardValue2 = 0;

                if (playerDeck1.ElementAt(0).Key <= 13) cardValue1 = playerDeck1.ElementAt(0).Key;
                else if (playerDeck1.ElementAt(0).Key > 13 && playerDeck1.ElementAt(0).Key <= 26) cardValue1 = playerDeck1.ElementAt(0).Key - 13;
                else if (playerDeck1.ElementAt(0).Key > 26 && playerDeck1.ElementAt(0).Key <= 39) cardValue1 = playerDeck1.ElementAt(0).Key - 26;
                else cardValue1 = playerDeck1.ElementAt(0).Key - 39;

                if (playerDeck2.ElementAt(0).Key <= 13) cardValue2 = playerDeck2.ElementAt(0).Key;
                else if (playerDeck2.ElementAt(0).Key > 13 && playerDeck2.ElementAt(0).Key <= 26) cardValue2 = playerDeck2.ElementAt(0).Key - 13;
                else if (playerDeck2.ElementAt(0).Key > 26 && playerDeck2.ElementAt(0).Key <= 39) cardValue2 = playerDeck2.ElementAt(0).Key - 26;
                else cardValue2 = playerDeck2.ElementAt(0).Key - 39;

                resultLabel1.Text += String.Format("The plunder:<br>&nbsp;&nbsp;{0}<br>&nbsp;&nbsp;{1}<br>", 
                    playerDeck1.ElementAt(0).Value, playerDeck2.ElementAt(0).Value);

                playerDeck1.RemoveAll(kvp => kvp.Key == battlePile.ElementAt(0).Key);
                playerDeck2.RemoveAll(kvp => kvp.Key == battlePile.ElementAt(1).Key);

                if (cardValue1 > cardValue2)
                {
                    playerDeck1.Add(new KeyValuePair<int, string>(battlePile.ElementAt(0).Key, battlePile.ElementAt(0).Value));
                    playerDeck1.Add(new KeyValuePair<int, string>(battlePile.ElementAt(1).Key, battlePile.ElementAt(1).Value));
                    battlePile.Clear();
                    resultLabel1.Text += "<strong>PLAYER ONE WINS!</strong>";
                }
                else if (cardValue1 < cardValue2)
                {
                    playerDeck2.Add(new KeyValuePair<int, string>(battlePile.ElementAt(0).Key, battlePile.ElementAt(0).Value));
                    playerDeck2.Add(new KeyValuePair<int, string>(battlePile.ElementAt(1).Key, battlePile.ElementAt(1).Value));
                    battlePile.Clear();
                    resultLabel1.Text += "<strong>PLAYER TWO WINS!</strong>";
                }
                else
                {
                    resultLabel1.Text += "<strong>IT'S WAAAAAAAAARRRRR!!!!</strong><br>";
                    resultLabel1.Text += String.Format("The plunder:<br>&nbsp;&nbsp;...from Player One: {0}<br>&nbsp;&nbsp;...from Player Two: {1}<br>&nbsp;&nbsp;...from Player One: {2}<br>&nbsp;&nbsp;...from Player Two: {3}<br>&nbsp;&nbsp;...from Player One: {4}<br>&nbsp;&nbsp;...from Player Two: {5}<br>",
                        playerDeck1.ElementAt(0).Value, playerDeck2.ElementAt(0).Value,
                        playerDeck1.ElementAt(1).Value, playerDeck2.ElementAt(1).Value,
                        playerDeck1.ElementAt(2).Value, playerDeck2.ElementAt(2).Value);
                    resultLabel1.Text += String.Format("...and the BATTLE: {0} versus {1}", playerDeck1.ElementAt(3).Value, playerDeck2.ElementAt(3).Value);

                    for (int j = 0; j < 4; j++)
                    {
                        battlePile.Add(playerDeck1.ElementAt(j).Key, playerDeck1.ElementAt(j).Value);
                        battlePile.Add(playerDeck2.ElementAt(j).Key, playerDeck2.ElementAt(j).Value);
                    }

                    if (playerDeck1.ElementAt(3).Key <= 13) cardValue1 = playerDeck1.ElementAt(3).Key;
                    else if (playerDeck1.ElementAt(3).Key > 13 && playerDeck1.ElementAt(3).Key <= 26) cardValue1 = playerDeck1.ElementAt(3).Key - 13;
                    else if (playerDeck1.ElementAt(3).Key > 26 && playerDeck1.ElementAt(3).Key <= 39) cardValue1 = playerDeck1.ElementAt(3).Key - 26;
                    else cardValue1 = playerDeck1.ElementAt(3).Key - 39;

                    if (playerDeck2.ElementAt(3).Key <= 13) cardValue2 = playerDeck2.ElementAt(3).Key;
                    else if (playerDeck2.ElementAt(3).Key > 13 && playerDeck2.ElementAt(3).Key <= 26) cardValue2 = playerDeck2.ElementAt(3).Key - 13;
                    else if (playerDeck2.ElementAt(3).Key > 26 && playerDeck2.ElementAt(3).Key <= 39) cardValue2 = playerDeck2.ElementAt(3).Key - 26;
                    else cardValue2 = playerDeck2.ElementAt(3).Key - 39;

                    for (int k = 0; k < 4; k++)
                    {
                        playerDeck1.Remove(new KeyValuePair<int, string>(playerDeck1.ElementAt(k).Key, playerDeck1.ElementAt(k).Value));
                        playerDeck2.Remove(new KeyValuePair<int, string>(playerDeck2.ElementAt(k).Key, playerDeck2.ElementAt(k).Value));
                    }

                    if (cardValue1 > cardValue2)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            playerDeck1.Add(new KeyValuePair<int, string>(battlePile.ElementAt(l).Key, battlePile.ElementAt(l).Value));
                        }

                        battlePile.Clear();

                        resultLabel1.Text += "<br><strong>PLAYER ONE WINS!</strong>";
                    }
                    else if (cardValue1 < cardValue2)
                    {
                        for (int l = 0; l < 10; l++)
                        {
                            playerDeck2.Add(new KeyValuePair<int, string>(battlePile.ElementAt(l).Key, battlePile.ElementAt(l).Value));
                        }

                        battlePile.Clear();
                        resultLabel1.Text += "<br><strong>PLAYER TWO WINS!</strong>";
                    }
                    else
                    {
                        resultLabel1.Text += "<br><strong>IT'S A TIE!!!</strong>";
                        battlePile.Clear();
                    }
                    battlePile.Clear();
                }
            }

            return 0;
        }
    }
}