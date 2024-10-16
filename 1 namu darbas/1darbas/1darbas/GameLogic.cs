using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text;
using System.Windows.Forms;

namespace _1darbas
{
    // Naudojama sealed klase
    public sealed class GameLogic : ICardAction
    {
        public int PlayerHealth { get; set; } = 100;
        public int OpponentHealth { get; set; } = 100;
        public Player Player { get; private set; }
        public List<Card> PlayerHand { get; set; }
        public List<Card> AIHand { get; set; }
        public List<(string CardName, int Strength)> UsedCards { get; set; } = new List<(string, int)>();
        private Random random = new Random();
        private Button buttonPlayCard;
        private Button buttonPlayCardComputer;
        private Label computerHandNewCard;

        private static GameLogic _instance;
        private static string playerName;

        public static GameLogic Instance => _instance ??= new GameLogic();
        public bool isPlayerTurn { get; private set; } = true;

        // Statinis konstruktorius
        static GameLogic()
        {
            playerName = PromptForPlayerName();
            Instance.Player = new Player(playerName);
            MessageBox.Show("GAME IS STARTING!");
        }

        private static string PromptForPlayerName()
        {
            string enteredPlayerName =  Microsoft.VisualBasic.Interaction.InputBox("Enter your name:", "Player Name", "Player1");

            if (string.IsNullOrWhiteSpace(enteredPlayerName))
            {
                enteredPlayerName = "Player1";
            }

            return enteredPlayerName;
        }

        public GameLogic()
        {
            PlayerHand = GenerateCards();
            AIHand = GenerateCards();
        }


        // params naudojimas
        public void SaveUsedCard(params (string CardName, int Strength)[] cards)
        {
            foreach (var card in cards)
            {
                UsedCards.Add(card);
            }
        }

        private List<Card> GenerateCards()
        {
            List<Card> hand = new List<Card>();

            while (hand.Count < 6) 
            {
                string cardName = $"Attack Card {hand.Count + 1}";
                int strength = random.Next(5, 31);
                var newCard = new Card(cardName, strength);

                if (!hand.Contains(newCard)) 
                {
                    hand.Add(newCard);
                }
            }

            for (int i = 0; i < 2; i++)
            {
                string cardName = $"Heal Card {i + 1}";
                int healAmount = random.Next(10, 21);
                var healCard = new Card(cardName, -healAmount);

                if (!hand.Contains(healCard))
                {
                    hand.Add(healCard);
                }
            }

            return hand;
        }


        public void PlayerTurn(Button buttonPlayCard, Button buttonPlayCardComputer, Label labelGameMessage, int selectedIndex, Label playerHandNewCard)
        {
            if (!isPlayerTurn) return;

            PlayCard(selectedIndex, labelGameMessage, playerHandNewCard);

            
            isPlayerTurn = false;

            buttonPlayCard.Enabled = false;
            buttonPlayCardComputer.Enabled = true;
        }

        public void OpponentTurn(Button buttonPlayCard, Button buttonPlayCardComputer, Label labelGameMessage, Label computerHandNewCard, Label playerHandNewCard)
        {
            if (isPlayerTurn) return;

            int randomIndex = random.Next(0, AIHand.Count);
            AIPlayCard(0..AIHand.Count, labelGameMessage, computerHandNewCard, playerHandNewCard);

            isPlayerTurn = true;

            buttonPlayCard.Enabled = true;
            buttonPlayCardComputer.Enabled = false;
        }

        public void PlayCard(int index, Label labelGameMessage, Label playerHandNewCard)
        {
            CheckGameOver(labelGameMessage, buttonPlayCard, playerHandNewCard, computerHandNewCard);

            if (index >= 0 && index < PlayerHand.Count)
            {
                var cardPlayed = PlayerHand[index];
                PlayerHand.RemoveAt(index);

                if (cardPlayed.Strength < 0)
                {
                    PlayerHealth -= cardPlayed.Strength;
                    labelGameMessage.Text = $"Played HEAL card: {cardPlayed.Name}, Player Health +{(-cardPlayed.Strength)}";
                    SaveUsedCard((cardPlayed.Name, cardPlayed.Strength));

                    string cardName = $"Heal Card";
                    int healAmount = random.Next(10, 21);

                    Card newHealCard;
                    do
                    {
                        newHealCard = new Card(cardName, -healAmount);
                        healAmount = random.Next(10, 21); 
                    } while (PlayerHand.Contains(newHealCard));

                    PlayerHand.Add(newHealCard);
                    playerHandNewCard.Text = $"Card added: {newHealCard.Name}, Heal Amount: {(-newHealCard.Strength)}"; 
                }
                else
                {
                    OpponentHealth -= cardPlayed.Strength;
                    labelGameMessage.Text = $"Played ATTACK card: {cardPlayed.Name}, Opponent Health -{cardPlayed.Strength}";
                    SaveUsedCard((cardPlayed.Name, cardPlayed.Strength));

                    string cardName = $"Attack Card";
                    int strength;

                    Card newAttackCard;
                    do
                    {
                        strength = random.Next(5, 31); 
                        newAttackCard = new Card(cardName, strength);
                    } while (PlayerHand.Contains(newAttackCard));

                    PlayerHand.Add(newAttackCard);
                    playerHandNewCard.Text = $"Card added: {newAttackCard.Name}, Strength: {newAttackCard.Strength}"; 
                }
            }
        }

        // Range tipo naudojimas
        public void AIPlayCard(Range range, Label labelGameMessage, Label computerHandNewCard, Label playerHandNewCard)
        {
            CheckGameOver(labelGameMessage, buttonPlayCard, playerHandNewCard, computerHandNewCard);

            int start = range.Start.Value;
            int end = range.End.Value;

            if (end > AIHand.Count)
            {
                end = AIHand.Count;
            }

            if (start < end)
            {
                int randomIndex = random.Next(start, end);
                Card cardPlayed = AIHand[randomIndex];
                AIHand.RemoveAt(randomIndex);

                if (cardPlayed.Strength < 0)
                {
                    OpponentHealth -= cardPlayed.Strength;
                    labelGameMessage.Text = $"AI played HEAL card: {cardPlayed.Name}, AI Health +{(-cardPlayed.Strength)}";

                    string cardName = $"Heal Card";
                    int healAmount = random.Next(10, 21);

                    Card newHealCard;
                    do
                    {
                        newHealCard = new Card(cardName, -healAmount);
                        healAmount = random.Next(10, 21);
                    } while (AIHand.Contains(newHealCard));

                    AIHand.Add(newHealCard);
                    computerHandNewCard.Text = $"Card added: {newHealCard.Name}, Heal Amount: {(-newHealCard.Strength)}";
                }
                else
                {
                    PlayerHealth -= cardPlayed.Strength;
                    labelGameMessage.Text = $"AI played ATTACK card: {cardPlayed.Name}, Player Health -{cardPlayed.Strength}";

                    string cardName = $"Attack Card";
                    int strength;

                    Card newAttackCard;
                    do
                    {
                        strength = random.Next(5, 31);
                        newAttackCard = new Card(cardName, strength);
                    } while (AIHand.Contains(newAttackCard));

                    AIHand.Add(newAttackCard);
                    computerHandNewCard.Text = $"Card added: {newAttackCard.Name}, Strength: {newAttackCard.Strength}";
                }
            }
        }

        public void SortPlayerHandByStrength()
        {
            PlayerHand.Sort();
        }

        public void CombineWeakestAttackCards(Label labelGameMessage)
        {
            var attackCards = PlayerHand.Where(card => card.Strength > 0).ToList();
            if (attackCards.Count < 2)
            {
                MessageBox.Show("Not enough attack cards to combine.");
                return;
            }

            var weakestCards = attackCards.OrderBy(card => card.Strength).Take(2).ToList();

            Card combinedCard = weakestCards[0] + weakestCards[1];

            OpponentHealth -= combinedCard.Strength;
            PlayerHand.Remove(weakestCards[0]);
            PlayerHand.Remove(weakestCards[1]);

            MessageBox.Show($"Combined '{weakestCards[0].Name}' and '{weakestCards[1].Name}' into '{combinedCard.Name}' with strength {combinedCard.Strength}.");

            labelGameMessage.Text = $"Combined attack: {combinedCard.Name}, Opponent Health -{combinedCard.Strength}";
            SaveUsedCard((combinedCard.Name, combinedCard.Strength));

            GenerateNewCards(2);
        }

        private void GenerateNewCards(int count)
        {
            for (int i = 0; i < count; i++)
            {
                string cardName = $"Attack Card {PlayerHand.Count + 1}";
                int strength = random.Next(5, 31);

                var newCard = new Card(cardName, strength);

                while (PlayerHand.Contains(newCard))
                {
                    strength = random.Next(5, 31);
                    newCard = new Card(cardName, strength);
                }

                PlayerHand.Add(newCard);
            }
        }


        // switch su when naudojimas
        public void CheckGameOver(Label labelGameMessage, Button buttonPlayCard, Label playerHandNewCard, Label computerHandNewCard)
        {
            StringBuilder usedCardsStringBuilder = new StringBuilder("Used Cards:\n");

            foreach (var (CardName, Strength) in UsedCards)
            {
                Card card = new Card(CardName, Strength);
                usedCardsStringBuilder.AppendLine(card.ToString("G", null));
            }

            switch (PlayerHealth, OpponentHealth)
            {
                case var (playerHealth, opponentHealth) when playerHealth <= 0:
                    MessageBox.Show($"Game Over! You lost.\n\n{usedCardsStringBuilder}");
                    EndGame(buttonPlayCard, labelGameMessage, playerHandNewCard, computerHandNewCard);
                    break;

                case var (playerHealth, opponentHealth) when opponentHealth <= 0:
                    MessageBox.Show($"Congratulations! You won.\n\n{usedCardsStringBuilder}");
                    EndGame(buttonPlayCard, labelGameMessage, playerHandNewCard, computerHandNewCard);
                    break;

                default:
                    break;
            }
        }

        private void EndGame(Button buttonPlayCard, Label labelGameMessage, Label playerHandNewCard, Label computerHandNewCard)
        {
            if (buttonPlayCard != null)
            {
                buttonPlayCard.Enabled = false;
            }
            DialogResult result = MessageBox.Show("Would you like to play again?", "Game Over", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                ResetGame(labelGameMessage, playerHandNewCard, computerHandNewCard);
                if (buttonPlayCard != null)
                {
                    buttonPlayCard.Enabled = true; 
                }
            }
            else
            {
                Application.Exit();
            }
        }

        public void ResetGame(Label labelGameMessage, Label playerHandNewCard, Label computerHandNewCard)
        {
            PlayerHealth = 100;
            OpponentHealth = 100;

            PlayerHand = GenerateCards();
            AIHand = GenerateCards();
            UsedCards.Clear();

            labelGameMessage.Text = string.Empty;
            playerHandNewCard.Text = string.Empty; 
            computerHandNewCard.Text = string.Empty;
        }


    }

}
