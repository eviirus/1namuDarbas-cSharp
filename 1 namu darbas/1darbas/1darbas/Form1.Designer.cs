namespace _1darbas
{
    partial class Game
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labelPlayerHealth = new Label();
            labelOpponentHealth = new Label();
            listBoxPlayerHand = new ListBox();
            listBoxOpponentHand = new ListBox();
            buttonPlayCard = new Button();
            labelGameMessage = new Label();
            labelGameMessageComputer = new Label();
            buttonSortPlayerHand = new Button();
            buttonCombineCards = new Button();
            playerHandNewCard = new Label();
            computerHandNewCard = new Label();
            cardInfo = new Button();
            SuspendLayout();
            // 
            // labelPlayerHealth
            // 
            labelPlayerHealth.AutoSize = true;
            labelPlayerHealth.Location = new Point(12, 9);
            labelPlayerHealth.Name = "labelPlayerHealth";
            labelPlayerHealth.Size = new Size(101, 15);
            labelPlayerHealth.TabIndex = 0;
            labelPlayerHealth.Text = "Player Health: 100";
            // 
            // labelOpponentHealth
            // 
            labelOpponentHealth.AutoSize = true;
            labelOpponentHealth.Location = new Point(749, 9);
            labelOpponentHealth.Name = "labelOpponentHealth";
            labelOpponentHealth.Size = new Size(123, 15);
            labelOpponentHealth.TabIndex = 1;
            labelOpponentHealth.Text = "Opponent Healht: 100";
            // 
            // listBoxPlayerHand
            // 
            listBoxPlayerHand.FormattingEnabled = true;
            listBoxPlayerHand.ItemHeight = 15;
            listBoxPlayerHand.Location = new Point(12, 27);
            listBoxPlayerHand.Name = "listBoxPlayerHand";
            listBoxPlayerHand.Size = new Size(300, 154);
            listBoxPlayerHand.TabIndex = 2;
            // 
            // listBoxOpponentHand
            // 
            listBoxOpponentHand.FormattingEnabled = true;
            listBoxOpponentHand.ItemHeight = 15;
            listBoxOpponentHand.Location = new Point(572, 27);
            listBoxOpponentHand.Name = "listBoxOpponentHand";
            listBoxOpponentHand.Size = new Size(300, 154);
            listBoxOpponentHand.TabIndex = 3;
            // 
            // buttonPlayCard
            // 
            buttonPlayCard.Location = new Point(12, 187);
            buttonPlayCard.Name = "buttonPlayCard";
            buttonPlayCard.Size = new Size(75, 23);
            buttonPlayCard.TabIndex = 4;
            buttonPlayCard.Text = "Play Card";
            buttonPlayCard.UseVisualStyleBackColor = true;
            buttonPlayCard.Click += buttonPlayCard_Click;
            // 
            // labelGameMessage
            // 
            labelGameMessage.AutoSize = true;
            labelGameMessage.Location = new Point(12, 238);
            labelGameMessage.Name = "labelGameMessage";
            labelGameMessage.Size = new Size(72, 15);
            labelGameMessage.TabIndex = 5;
            labelGameMessage.Text = "Player move";
            // 
            // labelGameMessageComputer
            // 
            labelGameMessageComputer.AccessibleName = "";
            labelGameMessageComputer.AutoSize = true;
            labelGameMessageComputer.ImageAlign = ContentAlignment.MiddleLeft;
            labelGameMessageComputer.Location = new Point(572, 238);
            labelGameMessageComputer.Name = "labelGameMessageComputer";
            labelGameMessageComputer.RightToLeft = RightToLeft.No;
            labelGameMessageComputer.Size = new Size(94, 15);
            labelGameMessageComputer.TabIndex = 6;
            labelGameMessageComputer.Text = "Computer move";
            labelGameMessageComputer.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonSortPlayerHand
            // 
            buttonSortPlayerHand.Location = new Point(198, 345);
            buttonSortPlayerHand.Name = "buttonSortPlayerHand";
            buttonSortPlayerHand.Size = new Size(114, 23);
            buttonSortPlayerHand.TabIndex = 7;
            buttonSortPlayerHand.Text = "Sort Player Hand";
            buttonSortPlayerHand.UseVisualStyleBackColor = true;
            buttonSortPlayerHand.Click += buttonSortPlayerHand_Click;
            // 
            // buttonCombineCards
            // 
            buttonCombineCards.Location = new Point(12, 345);
            buttonCombineCards.Name = "buttonCombineCards";
            buttonCombineCards.Size = new Size(141, 23);
            buttonCombineCards.TabIndex = 8;
            buttonCombineCards.Text = "Combine 2 weak cards";
            buttonCombineCards.UseVisualStyleBackColor = true;
            buttonCombineCards.Click += buttonCombineCards_Click;
            // 
            // playerHandNewCard
            // 
            playerHandNewCard.AutoSize = true;
            playerHandNewCard.Location = new Point(12, 288);
            playerHandNewCard.Name = "playerHandNewCard";
            playerHandNewCard.Size = new Size(57, 15);
            playerHandNewCard.TabIndex = 9;
            playerHandNewCard.Text = "New card";
            // 
            // computerHandNewCard
            // 
            computerHandNewCard.AutoSize = true;
            computerHandNewCard.Location = new Point(572, 288);
            computerHandNewCard.Name = "computerHandNewCard";
            computerHandNewCard.Size = new Size(57, 15);
            computerHandNewCard.TabIndex = 10;
            computerHandNewCard.Text = "New card";
            // 
            // cardInfo
            // 
            cardInfo.Location = new Point(12, 526);
            cardInfo.Name = "cardInfo";
            cardInfo.Size = new Size(75, 23);
            cardInfo.TabIndex = 11;
            cardInfo.Text = "Card Info";
            cardInfo.UseVisualStyleBackColor = true;
            cardInfo.Click += cardInfo_Click;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(cardInfo);
            Controls.Add(computerHandNewCard);
            Controls.Add(playerHandNewCard);
            Controls.Add(buttonCombineCards);
            Controls.Add(buttonSortPlayerHand);
            Controls.Add(labelGameMessageComputer);
            Controls.Add(labelGameMessage);
            Controls.Add(buttonPlayCard);
            Controls.Add(listBoxOpponentHand);
            Controls.Add(listBoxPlayerHand);
            Controls.Add(labelOpponentHealth);
            Controls.Add(labelPlayerHealth);
            Name = "Game";
            Text = "Game";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelPlayerHealth;
        private Label labelOpponentHealth;
        private ListBox listBoxPlayerHand;
        private ListBox listBoxOpponentHand;
        private Button buttonPlayCard;
        private Label labelGameMessage;
        private Label labelGameMessageComputer;
        private Control buttonSortHand_Click;
        private Button buttonSortPlayerHand;
        private Button buttonCombineCards;
        private Label playerHandNewCard;
        private Label computerHandNewCard;
        private Button cardInfo;
    }
}
