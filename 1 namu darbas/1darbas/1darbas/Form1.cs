using System;
using System.Diagnostics;
using System.Xml.Linq;
using Timer = System.Windows.Forms.Timer;

namespace _1darbas
{
    public partial class Game : Form
    {
        private GameLogic _game = new GameLogic();
        private Random random = new Random();
        private bool isPlayerTurn = true;
        string playerName = GameLogic.Instance.Player.Name;
        public Game()
        {
            InitializeComponent();
            listBoxOpponentHand.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateUI();
            labelGameMessage.Text = $"{playerName}'s turn. Please play a card.";
        }

        private void buttonPlayCard_Click(object sender, EventArgs e)
        {
            if (!isPlayerTurn)
            {
                MessageBox.Show("It's not your turn!");
                return;
            }

            if (listBoxPlayerHand.SelectedIndex >= 0)
            {
                _game.PlayCard(listBoxPlayerHand.SelectedIndex, labelGameMessage, playerHandNewCard);

                isPlayerTurn = false;
                UpdateUI();


                // Lambda naudojimas
                Timer aiTurnTimer = new Timer();
                aiTurnTimer.Interval = 1000;
                aiTurnTimer.Tick += (s, ev) =>
                {
                    aiTurnTimer.Stop();
                    buttonPlayCardComputer_Click(null, null);
                };
                aiTurnTimer.Start();
            }
        }

        private void buttonPlayCardComputer_Click(object sender, EventArgs e)
        {
            if (isPlayerTurn)
            {
                return;
            }

            int aiCardIndex = random.Next(_game.AIHand.Count);
            _game.AIPlayCard(0.._game.AIHand.Count, labelGameMessageComputer, computerHandNewCard, playerHandNewCard);

            isPlayerTurn = true;
            UpdateUI();

            labelGameMessage.Text = $"{playerName}'s. Please play a card.";
        }

        private void UpdateUI()
        {
            labelPlayerHealth.Text = $"{playerName} Health: {_game.PlayerHealth}";
            labelOpponentHealth.Text = $"Opponent Health: {_game.OpponentHealth}";

            listBoxPlayerHand.Items.Clear();
            foreach (var card in _game.PlayerHand)
            {
                listBoxPlayerHand.Items.Add(card);
            }

            listBoxOpponentHand.Items.Clear();
            foreach (var card in _game.AIHand)
            {
                listBoxOpponentHand.Items.Add(card);
            }
        }

        // Realizuota inicializicija naudojant out argumentus
        private void GetCardInfo(int index, out string name, out int strength)
        {
            if (index >= 0 && index < _game.PlayerHand.Count)
            {
                var card = _game.PlayerHand[index];
                card.Deconstruct(out name, out strength);
            }
            else
            {
                name = null;
                strength = 0;
            }
        }

        private void cardInfo_Click(object sender, EventArgs e)
        {
            if (listBoxPlayerHand.SelectedIndex >= 0)
            {
                GetCardInfo(listBoxPlayerHand.SelectedIndex, out string cardName, out int cardStrength);

                if (!string.IsNullOrEmpty(cardName))
                {
                    MessageBox.Show($"Card Name: {cardName}, Strength: {cardStrength}");
                }
                else
                {
                    MessageBox.Show("Unable to retrieve card information.");
                }
            }
            else
            {
                MessageBox.Show("Please select a card from your hand to view its information.");
            }
        }

        private void buttonSortPlayerHand_Click(object sender, EventArgs e)
        {
            _game.SortPlayerHandByStrength();
            UpdateUI();
        }

        private void buttonCombineCards_Click(object sender, EventArgs e)
        {
            _game.CombineWeakestAttackCards(labelGameMessage);
            UpdateUI();
        }

        
    }

}
