using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MonopolyDeal
{
    public enum Card
    {
        One,
        Two,
        Three,
        Four,
        Five,
        Ten,
        PassGo__1,
        DoubleTheRent__1,
        Birthday__2,
        House__3,
        Hotel__4,
        JustSayNo__4,
        DealBreaker__5,
        SlyDeal__3,
        ForcedDeal__3,
        DebtCollector__3,
        Rent,
        RentWild__3,
        RentBrownLightBlue__1,
        RentRedYellow__1,
        RentGreenBlue__1,
        RentPinkOrange__1,
        RentBlackLime__1,
        PropertyBrown__1,
        PropertyLime__1,
        PropertyBlue__4,
        PropertyLightBlue__1,
        PropertyPink__2,
        PropertyOrange__2,
        PropertyRed__3,
        PropertyYellow__3,
        PropertyGreen__4,
        PropertyBlack__2,
        PropertyWild,
        PropertyRedYellow__3,
        PropertyYellowRed__3,
        PropertyPinkOrange__2,
        PropertyOrangePink__2,
        PropertyLightBlueBlack__4,
        PropertyBlackLightBlue__4,
        PropertyLimeBlack__2,
        PropertyBlackLime__2,
        PropertyBrownLightBlue__1,
        PropertyLightBlueBrown__1,
        PropertyBlueGreen__4,
        PropertyGreenBlue__4,
        PropertyGreenBlack__4,
        PropertyBlackGreen__4,
        PropertyWildBrown,
        PropertyWildLime,
        PropertyWildBlue,
        PropertyWildLightBlue,
        PropertyWildPink,
        PropertyWildOrange,
        PropertyWildRed,
        PropertyWildYellow,
        PropertyWildGreen,
        PropertyWildBlack
    }

    public enum CardType
    {
        Action,
        Money,
        Property,
        Error
    }

    public enum PropertyType
    {
        Normal,
        Duo,
        Wild,
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<Card> deckShuffled = new List<Card>();

        public static List<Card> deckDiscard = new List<Card>();

        public static int numOfPlayers = 3;

        public static List<string> playerNames = new List<string>(){"Eric","Loser2","Loser3","Loser4","Loser5","Loser6"};

        public static List<List<ListBox>> otherTable_Money = new List<List<ListBox>>();

        public static List<List<ListBox>> otherTable_Properties = new List<List<ListBox>>();

        public static List<List<Button>> otherNames = new List<List<Button>>();

        public static List<List<TextBox>> otherMoneyLabels = new List<List<TextBox>>();

        public static List<List<TextBox>> otherPropertyLabels = new List<List<TextBox>>();

        public static int cardsToDeal = 5;

        public static bool gameContinues = true;

        public static int playerNum = 0;

        public static int chosenPlayer = 0;

        public static int cardNum;

        public static int cardNum2;

        public static int propIndex;

        public static int propIndex2;

        public static CardType cardType;

        public static int playNum;

        public static int payment;

        public static Card rentCard;

        public static Card propertyCard;

        public static Card playedCard;

        public static PropertyType propertyType;

        public static List<int> payersLeft = new List<int>();

        //public static List<List<bool>> isMonopoly = new List<List<bool>>();

        public static int monopolyIndex1;

        public static int monopolyIndex2;

        public static List<List<bool>> hasBeenRented = new List<List<bool>>();

        public static bool doublePlayed = false;

        public static bool doublePlayed2 = false;

        public static List<int> monopolyPropsNeeded = new List<int>() { 2, 2, 2, 3, 3, 3, 3, 3, 3, 4, 20};

        //public static List<int> numOfMonopolies = new List<int>();

        public static List<List<Card>> AllHands = new List<List<Card>>();

        public static List<List<Card>> AllTableMoney = new List<List<Card>>();

        //Heirarchy... 
        //1: All properties on table
        //2: Individual's properties
        //3: Individual's properties of certain color
        //[brown,lime,blue,lightblue,pink,orange,red,yellow,green,black]
        public static List<List<List<Card>>> AllTableProperties = new List<List<List<Card>>>();

        public static turnStage stage = new turnStage();

        public enum turnStage
        {
            begin,
            ready,
            decidePlayType,
            moveCards,
            moveCardsDecideType,
            moveCardsDecideTypeWild,
            checkMoveCard,
            playCardFromeHand,
            decideCardType,
            decidePropertyType,
            decidePropertyTypeWild,
            checkPlayCard,
            discard,
            checkDiscard,
            house,
            checkHouse,
            hotel,
            checkHotel,
            debtCollect,
            birthday,
            forcedDeal1,
            forcedDeal2,
            receiveForcedDeal,
            slyDeal,
            dealBreaker,
            rentWild,
            rentWild2,
            rent,
            doubleRent,
            doubleRentWild,
            checkRent,
            acknowledgeAttack,
        }

        public static List<playerTurn> playerTurns = new List<playerTurn>();


        #region Deck Definitions

        /// <summary>
        /// Unshuffled Deck
        /// </summary>
        public static List<Card> deckBeginning = new List<Card>()
        {
            Card.One,
            Card.One,
            Card.One,
            Card.One,
            Card.One,
            Card.One,
            Card.Two,
            Card.Two,
            Card.Two,
            Card.Two,
            Card.Two,
            Card.Three,
            Card.Three,
            Card.Three,
            Card.Four,
            Card.Four,
            Card.Four,
            Card.Five,
            Card.Five,
            Card.Ten,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.PassGo__1,
            Card.DoubleTheRent__1,
            Card.DoubleTheRent__1,
            Card.Birthday__2,
            Card.Birthday__2,
            Card.Birthday__2,
            Card.House__3,
            Card.House__3,
            Card.House__3,
            Card.Hotel__4,
            Card.Hotel__4,
            Card.SlyDeal__3,
            Card.SlyDeal__3,
            Card.SlyDeal__3,
            Card.ForcedDeal__3,
            Card.ForcedDeal__3,
            Card.ForcedDeal__3,
            Card.DebtCollector__3,
            Card.DebtCollector__3,
            Card.DebtCollector__3,
            Card.JustSayNo__4,
            Card.JustSayNo__4,
            Card.JustSayNo__4,
            Card.DealBreaker__5,
            Card.DealBreaker__5,
            Card.RentWild__3,
            Card.RentWild__3,
            Card.RentWild__3,
            Card.RentRedYellow__1,
            Card.RentRedYellow__1,
            Card.RentPinkOrange__1,
            Card.RentPinkOrange__1,
            Card.RentGreenBlue__1,
            Card.RentGreenBlue__1,
            Card.RentBrownLightBlue__1,
            Card.RentBrownLightBlue__1,
            Card.RentBlackLime__1,
            Card.RentBlackLime__1,
            Card.PropertyBlack__2,
            Card.PropertyBlack__2,
            Card.PropertyBlack__2,
            Card.PropertyBlack__2,
            Card.PropertyBlue__4,
            Card.PropertyBlue__4,
            Card.PropertyBrown__1,
            Card.PropertyBrown__1,
            Card.PropertyGreen__4,
            Card.PropertyGreen__4,
            Card.PropertyGreen__4,
            Card.PropertyLightBlue__1,
            Card.PropertyLightBlue__1,
            Card.PropertyLightBlue__1,
            Card.PropertyLime__1,
            Card.PropertyLime__1,
            Card.PropertyOrange__2,
            Card.PropertyOrange__2,
            Card.PropertyOrange__2,
            Card.PropertyPink__2,
            Card.PropertyPink__2,
            Card.PropertyPink__2,
            Card.PropertyRed__3,
            Card.PropertyRed__3,
            Card.PropertyRed__3,
            Card.PropertyWild,
            Card.PropertyWild,
            Card.PropertyYellow__3,
            Card.PropertyYellow__3,
            Card.PropertyYellow__3,
            Card.PropertyRedYellow__3,
            Card.PropertyRedYellow__3,
            Card.PropertyPinkOrange__2,
            Card.PropertyPinkOrange__2,
            Card.PropertyLightBlueBlack__4,
            Card.PropertyLimeBlack__2,
            Card.PropertyBrownLightBlue__1,
            Card.PropertyBlueGreen__4,
            Card.PropertyGreenBlack__4
        };
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            double left = 0;
            double top = 0;
            for (int i = 0; i < numOfPlayers; i++)
            {
                left = (i % 2) * 680;
                top = (i * 175) - (i % 2) * 175;
                playerTurns.Add(new playerTurn(i));
            }
            for (int i = 0; i < numOfPlayers; i++)
            {
                MainWindow.playerTurns[i].window.SizeChanged += MainWindow.window_SizeChanged;
                AllHands.Add(new List<Card>());
                AllTableMoney.Add(new List<Card>());
                AllTableProperties.Add(new List<List<Card>>());
                otherMoneyLabels.Add(new List<TextBox>());
                otherNames.Add(new List<Button>());
                otherPropertyLabels.Add(new List<TextBox>());
                otherTable_Money.Add(new List<ListBox>());
                otherTable_Properties.Add(new List<ListBox>());
                for (int j = 0; j < (numOfPlayers); j++)
                {
                    otherMoneyLabels[i].Add(new TextBox());
                    otherNames[i].Add(new Button());
                    otherPropertyLabels[i].Add(new TextBox());
                    otherTable_Money[i].Add(new ListBox());
                    otherTable_Properties[i].Add(new ListBox());
                }
                //isMonopoly.Add(new List<bool>());
                hasBeenRented.Add(new List<bool>());
                for (int j = 0; j < 11; j++)
                {
                    AllTableProperties[i].Add(new List<Card>());
                    //isMonopoly[i].Add(false);
                    hasBeenRented[i].Add(false);
                }
            }
            setupLayout();
            shuffleDeck();
            dealDeck();
            playerTurns[0].beginTurn(0);
            this.Hide();
        }

        public static void setupLayout()
        {
            for (int player = 0; player < numOfPlayers; player++)
            {
                double totalWidth = MainWindow.playerTurns[player].window.RenderSize.Width;
                double totalHeight = MainWindow.playerTurns[player].window.RenderSize.Height;
                double boxWidth = 7 * totalWidth / 48;
                double boxHeight = totalHeight / 4;
                MainWindow.playerTurns[player].grid.Width = totalWidth;
                MainWindow.playerTurns[player].grid.Height = totalHeight;
                MainWindow.playerTurns[player].grid.Margin = new Thickness(0, 0, 0, 0);
                MainWindow.playerTurns[player].Hand.Width = boxWidth;
                MainWindow.playerTurns[player].Table_Money.Width = boxWidth;
                MainWindow.playerTurns[player].Table_Properties.Width = boxWidth;
                MainWindow.playerTurns[player].Hand.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].Table_Money.Margin = new Thickness(boxWidth + ((totalWidth / 2 - 3 * boxWidth) / 2), totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].Table_Properties.Margin = new Thickness(2 * boxWidth + 5 * (totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].handLabel.Width = boxWidth;
                MainWindow.playerTurns[player].handLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].handLabel.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].moneyLabel.Width = boxWidth;
                MainWindow.playerTurns[player].moneyLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].moneyLabel.Margin = new Thickness(boxWidth + ((totalWidth / 2 - 3 * boxWidth) / 2), 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].propertiesLabel.Width = boxWidth;
                MainWindow.playerTurns[player].propertiesLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].propertiesLabel.Margin = new Thickness(2 * boxWidth + 5 * (totalWidth / 2 - 3 * boxWidth) / 6, 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].buttonPlayer.Width = totalWidth / 16;
                MainWindow.playerTurns[player].buttonPlayer.Height = 5 * totalHeight / 96;
                MainWindow.playerTurns[player].buttonPlayer.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].Prompt.Width = 10 * totalWidth / 32;
                MainWindow.playerTurns[player].Prompt.Height = 5 * totalHeight / 96;
                MainWindow.playerTurns[player].Prompt.Margin = new Thickness(4 * totalWidth / 48, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].cardsLeftText.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].cardsLeftText.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].cardsLeftText.Margin = new Thickness(39 * totalWidth / 96, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].deckCountDisplay.Width = 2 * totalWidth / 64;
                MainWindow.playerTurns[player].deckCountDisplay.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].deckCountDisplay.Margin = new Thickness(30 * totalWidth / 64, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].turnsLeftText.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].turnsLeftText.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].turnsLeftText.Margin = new Thickness(39 * totalWidth / 96, 4 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].turnsLeftDisplay.Width = 2 * totalWidth / 64;
                MainWindow.playerTurns[player].turnsLeftDisplay.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].turnsLeftDisplay.Margin = new Thickness(30 * totalWidth / 64, 4 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].buttonBack.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].buttonBack.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].buttonBack.Margin = new Thickness(totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button1.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button1.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button1.Margin = new Thickness(8 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button2.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button2.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button2.Margin = new Thickness(21 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button3.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button3.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button3.Margin = new Thickness(34 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);

                int otherPlayers = 0;
                for (int playerNum = 0; playerNum < MainWindow.numOfPlayers; playerNum++)
                {
                    double otherBoxWidth = totalWidth / ((MainWindow.numOfPlayers - 1) * 2 + 1);
                    otherBoxWidth = Math.Min(otherBoxWidth, boxWidth);
                    double otherBoxHeight = totalHeight / 4;
                    double otherMargin = (totalWidth - otherBoxWidth * 2 * (MainWindow.numOfPlayers - 1)) / (3 * (MainWindow.numOfPlayers - 1));
                    if (playerNum != player)
                    {
                        MainWindow.playerTurns[player].grid.Children.Add(MainWindow.otherTable_Properties[player][playerNum]);
                        MainWindow.otherTable_Properties[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherTable_Properties[player][playerNum].Height = otherBoxHeight;
                        MainWindow.otherTable_Properties[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherTable_Properties[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherTable_Properties[player][playerNum].Margin = new Thickness(otherMargin * (2 + 3 * otherPlayers) + otherBoxWidth * (2 * otherPlayers + 1), 5 * totalHeight / 8, 0, 0);
                        MainWindow.otherTable_Properties[player][playerNum].Name = MainWindow.playerNames[playerNum];
                        //MainWindow.otherTable_Properties[player][playerNum].MouseDoubleClick += MainWindow.playerTurns[MainWindow.playerNum].OtherPlayer_Properties_MouseDoubleClick;
                        MainWindow.playerTurns[player].grid.Children.Add(MainWindow.otherTable_Money[player][playerNum]);
                        MainWindow.otherTable_Money[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherTable_Money[player][playerNum].Height = otherBoxHeight;
                        MainWindow.otherTable_Money[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherTable_Money[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherTable_Money[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 5 * totalHeight / 8, 0, 0);
                        MainWindow.playerTurns[player].grid.Children.Add(MainWindow.otherNames[player][playerNum]);
                        MainWindow.otherNames[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherNames[player][playerNum].Width = 2 * otherBoxWidth + otherMargin;
                        MainWindow.otherNames[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherNames[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherNames[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 50 * totalHeight / 96, 0, 0);
                        MainWindow.otherNames[player][playerNum].Content = MainWindow.playerNames[playerNum];
                        MainWindow.otherNames[player][playerNum].HorizontalContentAlignment = HorizontalAlignment.Center;
                        MainWindow.otherNames[player][playerNum].VerticalContentAlignment = VerticalAlignment.Center;
                        MainWindow.otherNames[player][playerNum].Background = Brushes.DarkRed;
                        //MainWindow.otherNames[player][playerNum].Click += MainWindow.playerTurns[MainWindow.playerNum].OtherPlayer_Click;
                        MainWindow.playerTurns[player].grid.Children.Add(MainWindow.otherMoneyLabels[player][playerNum]);
                        MainWindow.otherMoneyLabels[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherMoneyLabels[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherMoneyLabels[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherMoneyLabels[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherMoneyLabels[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 55 * totalHeight / 96, 0, 0);
                        MainWindow.otherMoneyLabels[player][playerNum].Text = "Money:";
                        MainWindow.otherMoneyLabels[player][playerNum].TextAlignment = TextAlignment.Center;
                        MainWindow.playerTurns[player].grid.Children.Add(MainWindow.otherPropertyLabels[player][playerNum]);
                        MainWindow.otherPropertyLabels[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherPropertyLabels[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherPropertyLabels[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherPropertyLabels[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherPropertyLabels[player][playerNum].Margin = new Thickness(otherMargin * (2 + 3 * otherPlayers) + otherBoxWidth * (2 * otherPlayers + 1), 55 * totalHeight / 96, 0, 0);
                        MainWindow.otherPropertyLabels[player][playerNum].Text = "Properties:";
                        MainWindow.otherPropertyLabels[player][playerNum].TextAlignment = TextAlignment.Center;
                        otherPlayers++;
                    }
                }
            }
        }

        public static void resizeLayout()
        {
            for (int player = 0; player < numOfPlayers; player++)
            {
                double totalWidth = MainWindow.playerTurns[player].window.RenderSize.Width;
                double totalHeight = MainWindow.playerTurns[player].window.RenderSize.Height;
                double boxWidth = 7 * totalWidth / 48;
                double boxHeight = totalHeight / 4;
                MainWindow.playerTurns[player].grid.Width = totalWidth;
                MainWindow.playerTurns[player].grid.Height = totalHeight;
                MainWindow.playerTurns[player].grid.Margin = new Thickness(0, 0, 0, 0);
                MainWindow.playerTurns[player].Hand.Width = boxWidth;
                MainWindow.playerTurns[player].Table_Money.Width = boxWidth;
                MainWindow.playerTurns[player].Table_Properties.Width = boxWidth;
                MainWindow.playerTurns[player].Hand.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].Table_Money.Margin = new Thickness(boxWidth + ((totalWidth / 2 - 3 * boxWidth) / 2), totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].Table_Properties.Margin = new Thickness(2 * boxWidth + 5 * (totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 8, 0, 0);
                MainWindow.playerTurns[player].handLabel.Width = boxWidth;
                MainWindow.playerTurns[player].handLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].handLabel.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].moneyLabel.Width = boxWidth;
                MainWindow.playerTurns[player].moneyLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].moneyLabel.Margin = new Thickness(boxWidth + ((totalWidth / 2 - 3 * boxWidth) / 2), 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].propertiesLabel.Width = boxWidth;
                MainWindow.playerTurns[player].propertiesLabel.Height = totalHeight / 24;
                MainWindow.playerTurns[player].propertiesLabel.Margin = new Thickness(2 * boxWidth + 5 * (totalWidth / 2 - 3 * boxWidth) / 6, 7 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].buttonPlayer.Width = totalWidth / 16;
                MainWindow.playerTurns[player].buttonPlayer.Height = 5 * totalHeight / 96;
                MainWindow.playerTurns[player].buttonPlayer.Margin = new Thickness((totalWidth / 2 - 3 * boxWidth) / 6, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].Prompt.Width = 10 * totalWidth / 32;
                MainWindow.playerTurns[player].Prompt.Height = 5 * totalHeight / 96;
                MainWindow.playerTurns[player].Prompt.Margin = new Thickness(4 * totalWidth / 48, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].cardsLeftText.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].cardsLeftText.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].cardsLeftText.Margin = new Thickness(39 * totalWidth / 96, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].deckCountDisplay.Width = 2 * totalWidth / 64;
                MainWindow.playerTurns[player].deckCountDisplay.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].deckCountDisplay.Margin = new Thickness(30 * totalWidth / 64, totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].turnsLeftText.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].turnsLeftText.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].turnsLeftText.Margin = new Thickness(39 * totalWidth / 96, 4 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].turnsLeftDisplay.Width = 2 * totalWidth / 64;
                MainWindow.playerTurns[player].turnsLeftDisplay.Height = 2 * totalHeight / 96;
                MainWindow.playerTurns[player].turnsLeftDisplay.Margin = new Thickness(30 * totalWidth / 64, 4 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].buttonBack.Width = 4 * totalWidth / 64;
                MainWindow.playerTurns[player].buttonBack.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].buttonBack.Margin = new Thickness(totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button1.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button1.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button1.Margin = new Thickness(8 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button2.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button2.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button2.Margin = new Thickness(21 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);
                MainWindow.playerTurns[player].button3.Width = 8 * totalWidth / 64;
                MainWindow.playerTurns[player].button3.Height = 6 * totalHeight / 96;
                MainWindow.playerTurns[player].button3.Margin = new Thickness(34 * totalWidth / 96, 37 * totalHeight / 96, 0, 0);

                int otherPlayers = 0;
                for (int playerNum = 0; playerNum < MainWindow.numOfPlayers; playerNum++)
                {
                    double otherBoxWidth = totalWidth / ((MainWindow.numOfPlayers - 1) * 2 + 1);
                    otherBoxWidth = Math.Min(otherBoxWidth, boxWidth);
                    double otherBoxHeight = totalHeight / 4;
                    double otherMargin = (totalWidth - otherBoxWidth * 2 * (MainWindow.numOfPlayers - 1)) / (3 * (MainWindow.numOfPlayers - 1));
                    if (playerNum != player)
                    {
                        MainWindow.otherTable_Properties[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherTable_Properties[player][playerNum].Height = otherBoxHeight;
                        MainWindow.otherTable_Properties[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherTable_Properties[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherTable_Properties[player][playerNum].Margin = new Thickness(otherMargin * (2 + 3 * otherPlayers) + otherBoxWidth * (2 * otherPlayers + 1), 5 * totalHeight / 8, 0, 0);
                        MainWindow.otherTable_Properties[player][playerNum].Name = MainWindow.playerNames[playerNum];
                        MainWindow.otherTable_Money[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherTable_Money[player][playerNum].Height = otherBoxHeight;
                        MainWindow.otherTable_Money[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherTable_Money[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherTable_Money[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 5 * totalHeight / 8, 0, 0);
                        MainWindow.otherNames[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherNames[player][playerNum].Width = 2 * otherBoxWidth + otherMargin;
                        MainWindow.otherNames[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherNames[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherNames[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 50 * totalHeight / 96, 0, 0);
                        MainWindow.otherNames[player][playerNum].Content = MainWindow.playerNames[playerNum];
                        MainWindow.otherNames[player][playerNum].HorizontalContentAlignment = HorizontalAlignment.Center;
                        MainWindow.otherNames[player][playerNum].VerticalContentAlignment = VerticalAlignment.Center;
                        MainWindow.otherNames[player][playerNum].Background = Brushes.DarkRed;
                        MainWindow.otherMoneyLabels[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherMoneyLabels[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherMoneyLabels[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherMoneyLabels[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherMoneyLabels[player][playerNum].Margin = new Thickness(otherMargin * (3 * otherPlayers + 1) + 2 * otherBoxWidth * otherPlayers, 55 * totalHeight / 96, 0, 0);
                        MainWindow.otherMoneyLabels[player][playerNum].Text = "Money:";
                        MainWindow.otherMoneyLabels[player][playerNum].TextAlignment = TextAlignment.Center;
                        MainWindow.otherPropertyLabels[player][playerNum].Height = totalHeight / 24;
                        MainWindow.otherPropertyLabels[player][playerNum].Width = otherBoxWidth;
                        MainWindow.otherPropertyLabels[player][playerNum].HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                        MainWindow.otherPropertyLabels[player][playerNum].VerticalAlignment = System.Windows.VerticalAlignment.Top;
                        MainWindow.otherPropertyLabels[player][playerNum].Margin = new Thickness(otherMargin * (2 + 3 * otherPlayers) + otherBoxWidth * (2 * otherPlayers + 1), 55 * totalHeight / 96, 0, 0);
                        MainWindow.otherPropertyLabels[player][playerNum].Text = "Properties:";
                        MainWindow.otherPropertyLabels[player][playerNum].TextAlignment = TextAlignment.Center;
                        otherPlayers++;
                    }
                }
            }
        }

        public static void shuffleDeck()
        {
            List<Card> deckBeginningDuplicate = new List<Card>(deckBeginning);
            int numOfCards = deckBeginning.Count;
            Random rnd = new Random();
            for (int i = 0; i < numOfCards; i++)
            {
                int randomNum = rnd.Next(0, numOfCards - 1 - i);
                deckShuffled.Add(deckBeginningDuplicate[randomNum]);
                deckBeginningDuplicate.RemoveAt(randomNum);
            }
        }

        public static void shuffleDiscards()
        {
             List<Card> deckDuplicate = new List<Card>(deckDiscard);
            int numOfCards = deckDiscard.Count;
            Random rnd = new Random();
            for (int i = 0; i < numOfCards; i++)
            {
                int randomNum = rnd.Next(0, numOfCards - 1 - i);
                deckShuffled.Add(deckDuplicate[randomNum]);
                deckDuplicate.RemoveAt(randomNum);
            }
        }

        public static void dealDeck()
        {
            for (int cardNum = 0; cardNum < cardsToDeal; cardNum++)
            {
                for (int player = 0; player < numOfPlayers; player++)
                {
                    AllHands[player].Add(deckShuffled[0]);
                    deckShuffled.RemoveAt(0);
                }
            }
        }

        public static void sortMoney()
        {
            for (int player = 0; player < MainWindow.numOfPlayers; player++)
            {
                List<Card> newMoney= new List<Card>();
                int count = MainWindow.AllTableMoney[player].Count;
                while (newMoney.Count < count)
                {
                    int minValue = 20;
                    Card minCard = Card.Ten;
                    for (int index = 0; index < MainWindow.AllTableMoney[player].Count; index++)
                    {
                        int currentValue = getValue(MainWindow.AllTableMoney[player][index]);
                        if (currentValue < minValue)
                        {
                            minValue = currentValue;
                            minCard = MainWindow.AllTableMoney[player][index];
                        }
                    }
                    newMoney.Add(minCard);
                    MainWindow.AllTableMoney[player].Remove(minCard);
                }
                MainWindow.AllTableMoney[player] = newMoney;
            }
        }

        public static CardType getCardType(Card card)
        {
            switch (card)
            {
                case Card.One:
                    return CardType.Money;
                case Card.Two:
                    return CardType.Money;
                case Card.Three:
                    return CardType.Money;
                case Card.Four:
                    return CardType.Money;
                case Card.Five:
                    return CardType.Money;
                case Card.Ten:
                    return CardType.Money;
                case Card.PassGo__1:
                    return CardType.Action;
                case Card.DoubleTheRent__1:
                    return CardType.Action;
                case Card.Birthday__2:
                    return CardType.Action;
                case Card.House__3:
                    return CardType.Action;
                case Card.Hotel__4:
                    return CardType.Action;
                case Card.JustSayNo__4:
                    return CardType.Action;
                case Card.DealBreaker__5:
                    return CardType.Action;
                case Card.SlyDeal__3:
                    return CardType.Action;
                case Card.ForcedDeal__3:
                    return CardType.Action;
                case Card.DebtCollector__3:
                    return CardType.Action;
                case Card.RentWild__3:
                    return CardType.Action;
                case Card.RentBrownLightBlue__1:
                    return CardType.Action;
                case Card.RentRedYellow__1:
                    return CardType.Action;
                case Card.RentGreenBlue__1:
                    return CardType.Action;
                case Card.RentPinkOrange__1:
                    return CardType.Action;
                case Card.RentBlackLime__1:
                    return CardType.Action;
                case Card.PropertyYellow__3:
                    return CardType.Property;
                case Card.PropertyOrange__2:
                    return CardType.Property;
                case Card.PropertyPink__2:
                    return CardType.Property;
                case Card.PropertyRed__3:
                    return CardType.Property;
                case Card.PropertyLightBlue__1:
                    return CardType.Property;
                case Card.PropertyGreen__4:
                    return CardType.Property;
                case Card.PropertyBlack__2:
                    return CardType.Property;
                case Card.PropertyBrown__1:
                    return CardType.Property;
                case Card.PropertyLime__1:
                    return CardType.Property;
                case Card.PropertyBlue__4:
                    return CardType.Property;
                case Card.PropertyWild:
                    return CardType.Property;
                case Card.PropertyRedYellow__3:
                    return CardType.Property;
                case Card.PropertyPinkOrange__2:
                    return CardType.Property;
                case Card.PropertyLightBlueBlack__4:
                    return CardType.Property;
                case Card.PropertyLimeBlack__2:
                    return CardType.Property;
                case Card.PropertyBrownLightBlue__1:
                    return CardType.Property;
                case Card.PropertyBlueGreen__4:
                    return CardType.Property;
                case Card.PropertyGreenBlack__4:
                    return CardType.Property;
            }
            return CardType.Error;
        }

        public static PropertyType getPropertyType(Card card)
        {
            switch (card)
            {
                case Card.PropertyYellow__3:
                    return PropertyType.Normal;
                case Card.PropertyOrange__2:
                    return PropertyType.Normal;
                case Card.PropertyPink__2:
                    return PropertyType.Normal;
                case Card.PropertyRed__3:
                    return PropertyType.Normal;
                case Card.PropertyLightBlue__1:
                    return PropertyType.Normal;
                case Card.PropertyGreen__4:
                    return PropertyType.Normal;
                case Card.PropertyBlack__2:
                    return PropertyType.Normal;
                case Card.PropertyBrown__1:
                    return PropertyType.Normal;
                case Card.PropertyLime__1:
                    return PropertyType.Normal;
                case Card.PropertyBlue__4:
                    return PropertyType.Normal;
                case Card.PropertyRedYellow__3:
                    return PropertyType.Duo;
                case Card.PropertyYellowRed__3:
                    return PropertyType.Duo;
                case Card.PropertyPinkOrange__2:
                    return PropertyType.Duo;
                case Card.PropertyOrangePink__2:
                    return PropertyType.Duo;
                case Card.PropertyLightBlueBlack__4:
                    return PropertyType.Duo;
                case Card.PropertyBlackLightBlue__4:
                    return PropertyType.Duo;
                case Card.PropertyLimeBlack__2:
                    return PropertyType.Duo;
                case Card.PropertyBlackLime__2:
                    return PropertyType.Duo;
                case Card.PropertyBrownLightBlue__1:
                    return PropertyType.Duo;
                case Card.PropertyLightBlueBrown__1:
                    return PropertyType.Duo;
                case Card.PropertyBlueGreen__4:
                    return PropertyType.Duo;
                case Card.PropertyGreenBlue__4:
                    return PropertyType.Duo;
                case Card.PropertyGreenBlack__4:
                    return PropertyType.Duo;
                case Card.PropertyBlackGreen__4:
                    return PropertyType.Duo;
                case Card.PropertyWild:
                    return PropertyType.Wild;
                case Card.PropertyWildBrown:
                    return PropertyType.Wild;
                case Card.PropertyWildLime:
                    return PropertyType.Wild;
                case Card.PropertyWildBlue:
                    return PropertyType.Wild;
                case Card.PropertyWildLightBlue:
                    return PropertyType.Wild;
                case Card.PropertyWildPink:
                    return PropertyType.Wild;
                case Card.PropertyWildOrange:
                    return PropertyType.Wild;
                case Card.PropertyWildRed:
                    return PropertyType.Wild;
                case Card.PropertyWildYellow:
                    return PropertyType.Wild;
                case Card.PropertyWildGreen:
                    return PropertyType.Wild;
                case Card.PropertyWildBlack:
                    return PropertyType.Wild;
            }
            return PropertyType.Normal;
        }

        public static int getValue(Card card)
        {
            switch (card)
            {
                case Card.One:
                    return 1;
                case Card.Two:
                    return 2;
                case Card.Three:
                    return 3;
                case Card.Four:
                    return 4;
                case Card.Five:
                    return 5;
                case Card.Ten:
                    return 10;
                case Card.PassGo__1:
                    return 1;
                case Card.DoubleTheRent__1:
                    return 1;
                case Card.Birthday__2:
                    return 2;
                case Card.House__3:
                    return 3;
                case Card.Hotel__4:
                    return 4;
                case Card.JustSayNo__4:
                    return 4;
                case Card.DealBreaker__5:
                    return 5;
                case Card.SlyDeal__3:
                    return 3;
                case Card.ForcedDeal__3:
                    return 3;
                case Card.DebtCollector__3:
                    return 3;
                case Card.RentWild__3:
                    return 3;
                case Card.RentBrownLightBlue__1:
                    return 1;
                case Card.RentRedYellow__1:
                    return 1;
                case Card.RentGreenBlue__1:
                    return 1;
                case Card.RentPinkOrange__1:
                    return 1;
                case Card.RentBlackLime__1:
                    return 1;
                case Card.PropertyYellow__3:
                    return 3;
                case Card.PropertyOrange__2:
                    return 2;
                case Card.PropertyPink__2:
                    return 2;
                case Card.PropertyRed__3:
                    return 3;
                case Card.PropertyLightBlue__1:
                    return 1;
                case Card.PropertyGreen__4:
                    return 4;
                case Card.PropertyBlack__2:
                    return 2;
                case Card.PropertyBrown__1:
                    return 1;
                case Card.PropertyLime__1:
                    return 1;
                case Card.PropertyBlue__4:
                    return 4;
                case Card.PropertyWild:
                    return 0;
                case Card.PropertyRedYellow__3:
                    return 3;
                case Card.PropertyYellowRed__3:
                    return 3;
                case Card.PropertyPinkOrange__2:
                    return 2;
                case Card.PropertyOrangePink__2:
                    return 2;
                case Card.PropertyLightBlueBlack__4:
                    return 4;
                case Card.PropertyBlackLightBlue__4:
                    return 4;
                case Card.PropertyLimeBlack__2:
                    return 2;
                case Card.PropertyBlackLime__2:
                    return 2;
                case Card.PropertyBrownLightBlue__1:
                    return 1;
                case Card.PropertyLightBlueBrown__1:
                    return 1;
                case Card.PropertyBlueGreen__4:
                    return 4;
                case Card.PropertyGreenBlue__4:
                    return 4;
                case Card.PropertyGreenBlack__4:
                    return 4;
                case Card.PropertyBlackGreen__4:
                    return 4;
                case Card.PropertyWildBrown:
                    return 0;
                case Card.PropertyWildLime:
                    return 0;
                case Card.PropertyWildBlue:
                    return 0;
                case Card.PropertyWildLightBlue:
                    return 0;
                case Card.PropertyWildPink:
                    return 0;
                case Card.PropertyWildOrange:
                    return 0;
                case Card.PropertyWildRed:
                    return 0;
                case Card.PropertyWildYellow:
                    return 0;
                case Card.PropertyWildGreen:
                    return 0;
                case Card.PropertyWildBlack:
                    return 0;
            }
            return 0;
        }

        //[brown,lime,blue,lightblue,pink,orange,red,yellow,green,black]
        public static int getPropertyIndex(Card card)
        {
            switch (card)
            {
                case Card.PropertyBrown__1:
                    return 0;
                case Card.PropertyBrownLightBlue__1:
                    return 0;
                case Card.PropertyWildBrown:
                    return 0;
                case Card.PropertyLime__1:
                    return 1;
                case Card.PropertyLimeBlack__2:
                    return 1;
                case Card.PropertyWildLime:
                    return 1;
                case Card.PropertyBlue__4:
                    return 2;
                case Card.PropertyBlueGreen__4:
                    return 2;
                case Card.PropertyWildBlue:
                    return 2;
                case Card.PropertyLightBlue__1:
                    return 3;
                case Card.PropertyLightBlueBlack__4:
                    return 3;
                case Card.PropertyLightBlueBrown__1:
                    return 3;
                case Card.PropertyWildLightBlue:
                    return 3;
                case Card.PropertyPink__2:
                    return 4;
                case Card.PropertyPinkOrange__2:
                    return 4;
                case Card.PropertyWildPink:
                    return 4;
                case Card.PropertyOrange__2:
                    return 5;
                case Card.PropertyOrangePink__2:
                    return 5;
                case Card.PropertyWildOrange:
                    return 5;
                case Card.PropertyRed__3:
                    return 6;
                case Card.PropertyRedYellow__3:
                    return 6;
                case Card.PropertyWildRed:
                    return 6;
                case Card.PropertyYellow__3:
                    return 7;
                case Card.PropertyYellowRed__3:
                    return 7;
                case Card.PropertyWildYellow:
                    return 7;
                case Card.PropertyGreen__4:
                    return 8;
                case Card.PropertyGreenBlack__4:
                    return 8;
                case Card.PropertyGreenBlue__4:
                    return 8;
                case Card.PropertyWildGreen:
                    return 8;
                case Card.PropertyBlack__2:
                    return 9;
                case Card.PropertyBlackGreen__4:
                    return 9;
                case Card.PropertyBlackLightBlue__4:
                    return 9;
                case Card.PropertyBlackLime__2:
                    return 9;
                case Card.PropertyWildBlack:
                    return 9;
                case Card.PropertyWild:
                    return 10;
            }
            return 11;
        }

        public static int getRentAmount()
        {
            int numOfProps = MainWindow.AllTableProperties[MainWindow.playerNum][MainWindow.propIndex].Count;
            switch (MainWindow.propIndex)
            {
                case 0:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 5;
                        case 4:
                            return 9;
                    }
                    return 100;

                case 1:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 5;
                        case 4:
                            return 9;
                    }
                    return 100;

                case 2:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 3;
                        case 2:
                            return 8;
                        case 3:
                            return 11;
                        case 4:
                            return 15;
                    }
                    return 100;

                case 3:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 3;
                        case 4:
                            return 6;
                        case 5:
                            return 10;
                    }
                    return 100;

                case 4:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 4;
                        case 4:
                            return 7;
                        case 5:
                            return 11;
                    }
                    return 100;

                case 5:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 3;
                        case 3:
                            return 5;
                        case 4:
                            return 8;
                        case 5:
                            return 12;
                    }
                    return 100;

                case 6:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 2;
                        case 2:
                            return 3;
                        case 3:
                            return 6;
                        case 4:
                            return 9;
                        case 5:
                            return 13;
                    }
                    return 100;

                case 7:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 2;
                        case 2:
                            return 4;
                        case 3:
                            return 6;
                        case 4:
                            return 9;
                        case 5:
                            return 13;
                    }
                    return 100;

                case 8:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 2;
                        case 2:
                            return 4;
                        case 3:
                            return 7;
                        case 4:
                            return 10;
                        case 5:
                            return 14;
                    }
                    return 100;

                case 9:
                    switch (numOfProps)
                    {
                        case 0:
                            return 0;
                        case 1:
                            return 1;
                        case 2:
                            return 2;
                        case 3:
                            return 3;
                        case 4:
                            return 4;
                        case 5:
                            return 7;
                        case 6:
                            return 11;
                    }
                    return 100;
            }
            return 0;
        }

        public static void updateMonopolies()
        {
            for (int player = 0; player < numOfPlayers; player++)
            {
                for (int propertyIndex = 0; propertyIndex < 10; propertyIndex++)
                {
                    if (AllTableProperties[player][propertyIndex].Count >= monopolyPropsNeeded[propertyIndex])
                    {
                        //isMonopoly[player][propertyIndex] = true;
                    }
                }
            }
        }

        public static int numOfHouseOptions()
        {
            int options = 0;
            for (int i = 0; i < 10; i++)
            {
                if (AllTableProperties[playerNum][i].Count == monopolyPropsNeeded[i])
                {
                    options++;
                }
            }
            return options;
        }

        public static int numOfHotelOptions()
        {
            int options = 0;
            for (int i = 0; i < 10; i++)
            {
                if (AllTableProperties[playerNum][i].Count == (monopolyPropsNeeded[i] + 1))
                {
                    options++;
                }
            }
            return options;
        }

        public static int numOfMonopolies()
        {
            int options = 0;
            for (int i = 0; i < 10; i++)
            {
                if (AllTableProperties[chosenPlayer][i].Count >= (monopolyPropsNeeded[i]))
                {
                    options++;
                }
            }
            return options;
        }

        //Check if houses and hotels are still valid...
        public static void checkProperties()
        {
            for (int player = 0; player<numOfPlayers;player++)
            {
                for (int index = 0; index < 10; index++)
                {
                    if (MainWindow.AllTableProperties[player][index].Contains(Card.House__3))
                    {
                        if (MainWindow.AllTableProperties[player][index].IndexOf(Card.House__3) < monopolyPropsNeeded[index])
                        {
                            MainWindow.AllTableMoney[player].Add(Card.House__3);
                            MainWindow.AllTableProperties[player][index].Remove(Card.House__3);
                        }
                    }
                    if (MainWindow.AllTableProperties[player][index].Contains(Card.Hotel__4))
                    {
                        if (MainWindow.AllTableProperties[player][index].IndexOf(Card.Hotel__4) <= monopolyPropsNeeded[index])
                        {
                            MainWindow.AllTableMoney[player].Add(Card.Hotel__4);
                            MainWindow.AllTableProperties[player][index].Remove(Card.Hotel__4);
                        }
                    }
                }
            }
        }

        public static bool checkForWinner()
        {
            for (int player = 0; player < MainWindow.numOfPlayers; player++)
            {
                int numOfMonopolies = 0;
                for (int cardIndex = 0; cardIndex < 10; cardIndex++)
                {
                    if (MainWindow.AllTableProperties[player][cardIndex].Count >= MainWindow.monopolyPropsNeeded[cardIndex])
                    {
                        numOfMonopolies++;
                    }
                }
                if (numOfMonopolies >= 3)
                {
                    MainWindow.playerNum = player;
                    MainWindow.endGame();
                    return true;
                }
            }
            return false;
        }

        public static void endGame()
        {
            for (int player = 0; player < MainWindow.numOfPlayers; player++)
            {
                MainWindow.playerTurns[player].button1.Visibility = Visibility.Hidden;
                MainWindow.playerTurns[player].button2.Visibility = Visibility.Hidden;
                MainWindow.playerTurns[player].button3.Visibility = Visibility.Hidden;
                MainWindow.playerTurns[player].buttonBack.Visibility = Visibility.Hidden;
                MainWindow.playerTurns[player].Prompt.Content = "Player " + MainWindow.playerNum + " won the game!  Get rocked!";
            }
            MainWindow.playerTurns[MainWindow.playerNum].Prompt.Content = "You won!!! Congratulations!";
        }

        public static void Table_Properties_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.stage == MainWindow.turnStage.acknowledgeAttack)
            {
                int totalValue = 0;
                int numOfWilds = 0;
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.Items)
                {
                    if (MainWindow.getPropertyType(card) == PropertyType.Wild)
                    {
                        numOfWilds++;
                    }
                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems)
                {
                    if (MainWindow.getPropertyType(card) == PropertyType.Wild)
                    {
                        numOfWilds--;
                    }
                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems)
                {
                    totalValue += MainWindow.getValue(card);

                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.SelectedItems)
                {
                    totalValue += MainWindow.getValue(card);
                }
                if ((totalValue >= MainWindow.payment) || ((MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems.Count >= (MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.Items.Count - numOfWilds)) && (MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.SelectedItems.Count == MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.Items.Count)))
                {
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Content = "Make Payment";
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        public static void Table_Money_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MainWindow.stage == MainWindow.turnStage.acknowledgeAttack)
            {
                int totalValue = 0;
                int numOfWilds = 0;
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.Items)
                {
                    if (MainWindow.getPropertyType(card) == PropertyType.Wild)
                    {
                        numOfWilds++;
                    }
                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems)
                {
                    if (MainWindow.getPropertyType(card) == PropertyType.Wild)
                    {
                        numOfWilds--;
                    }
                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems)
                {
                    totalValue += MainWindow.getValue(card);
                }
                foreach (Card card in MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.SelectedItems)
                {
                    totalValue += MainWindow.getValue(card);
                }
                if ((totalValue >= MainWindow.payment) || (((MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.SelectedItems.Count == MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Properties.Items.Count - numOfWilds)) && (MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.SelectedItems.Count == MainWindow.playerTurns[MainWindow.chosenPlayer].Table_Money.Items.Count)))
                {
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Content = "Make Payment";
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Visibility = System.Windows.Visibility.Visible;
                }
                else
                {
                    MainWindow.playerTurns[MainWindow.chosenPlayer].button3.Visibility = System.Windows.Visibility.Hidden;
                }
            }
        }

        public static void Table_Properties_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex < 0)
            {
                return;
            }
            //if (MainWindow.stage == MainWindow.turnStage.slyDeal)
            //{
            //    MainWindow.cardNum = Table_Properties.SelectedIndex;
            //    MainWindow.propertyCard = Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum);
            //    string chosenPlayer = buttonPlayer.Content.ToString();
            //    MainWindow.chosenPlayer = (chosenPlayer[7] - 49);
            //    MainWindow.propIndex = MainWindow.getPropertyIndex(MainWindow.propertyCard);
            //    MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.chosenPlayer][MainWindow.propIndex].IndexOf(MainWindow.propertyCard);
            //    if (MainWindow.chosenPlayer != MainWindow.playerNum)
            //    {
            //        MainWindow.playerTurns[MainWindow.playerNum].checkSlyDeal();
            //    }
            //}

            if (MainWindow.stage == MainWindow.turnStage.forcedDeal1)
            {
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex;
                Card currentCard = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum);
                MainWindow.propIndex = MainWindow.getPropertyIndex(currentCard);
                MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.playerNum][MainWindow.propIndex].IndexOf(currentCard);
                MainWindow.playerTurns[MainWindow.playerNum].playForcedDeal2();
            }
            //else if (MainWindow.stage == MainWindow.turnStage.forcedDeal2)
            //{
            //    MainWindow.cardNum2 = Table_Properties.SelectedIndex;
            //    MainWindow.propertyCard = Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum2);
            //    MainWindow.propIndex2 = MainWindow.getPropertyIndex(MainWindow.propertyCard);
            //    string chosenPlayer = buttonPlayer.Content.ToString();
            //    MainWindow.chosenPlayer = (chosenPlayer[7] - 49);
            //    MainWindow.cardNum2 = MainWindow.AllTableProperties[MainWindow.chosenPlayer][MainWindow.propIndex2].IndexOf(MainWindow.propertyCard);
            //    MainWindow.playerTurns[MainWindow.playerNum].checkForcedDeal();
            //}

            if (MainWindow.stage == MainWindow.turnStage.rentWild)
            {
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex;
                Card currentCard = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum);
                MainWindow.propIndex = MainWindow.getPropertyIndex(currentCard);
                MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.playerNum][MainWindow.propIndex].IndexOf(currentCard);
                MainWindow.payment = MainWindow.getRentAmount();
                if ((MainWindow.AllHands[MainWindow.playerNum].Contains(Card.DoubleTheRent__1)) && (MainWindow.playNum < 2))
                {
                    MainWindow.playerTurns[MainWindow.playerNum].askDoubleRentWild();
                }
                else
                {
                    MainWindow.playerTurns[MainWindow.playerNum].playRentWild2();
                }
            }

            if (MainWindow.stage == MainWindow.turnStage.decidePropertyTypeWild)
            {
                MainWindow.cardNum2 = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex;
                MainWindow.propertyCard = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum2);
                MainWindow.propIndex = MainWindow.getPropertyIndex(MainWindow.propertyCard);
                MainWindow.playerTurns[MainWindow.playerNum].checkPlayCard();
            }

            if (MainWindow.stage == MainWindow.turnStage.moveCards)
            {
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex;
                MainWindow.propertyCard = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum);
                //Problem... propIndex only helps IFF the property is in the normal stack.  This won't work for extra [10] stack
                //So... I will first check the extra stack [10] when I remove a card...
                if (MainWindow.AllTableProperties[MainWindow.playerNum][10].Contains(MainWindow.propertyCard))
                {
                    MainWindow.propIndex = 10;
                }
                else
                {
                    MainWindow.propIndex = MainWindow.getPropertyIndex(MainWindow.propertyCard);
                }
                MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.playerNum][MainWindow.propIndex].IndexOf(MainWindow.propertyCard);
                MainWindow.propertyType = MainWindow.getPropertyType(MainWindow.propertyCard);
                if (MainWindow.propertyType == PropertyType.Duo)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].moveCardsDecideType();
                }
                else if (MainWindow.propertyType == PropertyType.Wild)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].moveCardsDecideTypeWild();
                }
                else
                {
                    MainWindow.playerTurns[MainWindow.playerNum].Prompt.Content = "This card cannot be moved.";
                    MainWindow.playerTurns[MainWindow.playerNum].button1.Visibility = System.Windows.Visibility.Hidden;
                    MainWindow.playerTurns[MainWindow.playerNum].button2.Visibility = System.Windows.Visibility.Hidden;
                    MainWindow.playerTurns[MainWindow.playerNum].button3.Visibility = System.Windows.Visibility.Hidden;
                    MainWindow.playerTurns[MainWindow.playerNum].buttonBack.Visibility = System.Windows.Visibility.Visible;
                }
                return;
            }
            if (MainWindow.stage == MainWindow.turnStage.moveCardsDecideTypeWild)
            {
                MainWindow.cardNum2 = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.SelectedIndex;
                Card currentCard = MainWindow.playerTurns[MainWindow.playerNum].Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum2);
                MainWindow.propIndex2 = MainWindow.getPropertyIndex(currentCard);
                MainWindow.playerTurns[MainWindow.playerNum].checkMoveCard();
            }
        }

        public static void Hand_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (MainWindow.playerTurns[MainWindow.playerNum].Hand.SelectedIndex < 0)
            {
                return;
            }
            if (MainWindow.stage == MainWindow.turnStage.playCardFromeHand)
            {
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Hand.SelectedIndex;
                MainWindow.playerTurns[MainWindow.playerNum].decideCardType();
            }

            if (MainWindow.stage == MainWindow.turnStage.discard)
            {
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Hand.SelectedIndex;
                MainWindow.playerTurns[MainWindow.playerNum].checkDiscard();
            }

            if (MainWindow.stage == MainWindow.turnStage.slyDeal)
            {
                if (MainWindow.chosenPlayer != MainWindow.playerNum)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].checkSlyDeal();
                }
                MainWindow.cardNum = MainWindow.playerTurns[MainWindow.playerNum].Hand.SelectedIndex;
            }
        }

        public static void OtherPlayer_Click(object sender, RoutedEventArgs e)
        {
            Button copySender = (Button)sender;
            int playerClicked = MainWindow.otherNames[MainWindow.playerNum].IndexOf(copySender);

            if (MainWindow.stage == MainWindow.turnStage.debtCollect)
            {
                MainWindow.chosenPlayer = playerClicked;
                if (MainWindow.chosenPlayer != MainWindow.playerNum)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].checkDebtCollector();
                }
            }
            if (MainWindow.stage == MainWindow.turnStage.rentWild2)
            {
                MainWindow.chosenPlayer = playerClicked;
                if (MainWindow.chosenPlayer != MainWindow.playerNum)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].checkRentWild();
                }
            }
            if (MainWindow.stage == MainWindow.turnStage.dealBreaker)
            {
                MainWindow.chosenPlayer = playerClicked;
                if (MainWindow.chosenPlayer != MainWindow.playerNum)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].playDealBreaker2();
                }
            }
        }

        public static void OtherPlayer_Properties_MouseDoubleClick(object sender, RoutedEventArgs e)
        {
            ListBox copySender = (ListBox)sender;
            int playerClicked = MainWindow.otherTable_Properties[MainWindow.playerNum].IndexOf(copySender);

            if (MainWindow.otherTable_Properties[MainWindow.playerNum][playerClicked].SelectedIndex < 0)
            {
                return;
            }
            if (MainWindow.stage == MainWindow.turnStage.slyDeal)
            {
                MainWindow.cardNum = MainWindow.otherTable_Properties[MainWindow.playerNum][playerClicked].SelectedIndex;
                MainWindow.propertyCard = MainWindow.otherTable_Properties[MainWindow.playerNum][playerClicked].Items.Cast<Card>().ElementAt(MainWindow.cardNum);
                //string chosenPlayer = buttonPlayer.Content.ToString();
                MainWindow.chosenPlayer = playerClicked;
                MainWindow.propIndex = MainWindow.getPropertyIndex(MainWindow.propertyCard);
                MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.chosenPlayer][MainWindow.propIndex].IndexOf(MainWindow.propertyCard);
                if (MainWindow.chosenPlayer != MainWindow.playerNum)
                {
                    MainWindow.playerTurns[MainWindow.playerNum].checkSlyDeal();
                }
            }

            //if (MainWindow.stage == MainWindow.turnStage.forcedDeal1)
            //{
            //    MainWindow.cardNum = Table_Properties.SelectedIndex;
            //    Card currentCard = Table_Properties.Items.Cast<Card>().ElementAt(MainWindow.cardNum);
            //    MainWindow.propIndex = MainWindow.getPropertyIndex(currentCard);
            //    MainWindow.cardNum = MainWindow.AllTableProperties[MainWindow.playerNum][MainWindow.propIndex].IndexOf(currentCard);
            //    MainWindow.playerTurns[MainWindow.playerNum].playForcedDeal2();
            //}
            else if (MainWindow.stage == MainWindow.turnStage.forcedDeal2)
            {
                MainWindow.cardNum2 = MainWindow.otherTable_Properties[MainWindow.playerNum][playerClicked].SelectedIndex;
                MainWindow.propertyCard = MainWindow.otherTable_Properties[MainWindow.playerNum][playerClicked].Items.Cast<Card>().ElementAt(MainWindow.cardNum2);
                MainWindow.propIndex2 = MainWindow.getPropertyIndex(MainWindow.propertyCard);
                //string chosenPlayer = buttonPlayer.Content.ToString();
                MainWindow.chosenPlayer = playerClicked;
                MainWindow.cardNum2 = MainWindow.AllTableProperties[MainWindow.chosenPlayer][MainWindow.propIndex2].IndexOf(MainWindow.propertyCard);
                MainWindow.playerTurns[MainWindow.playerNum].checkForcedDeal();
            }
        }

        public static void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            MainWindow.resizeLayout();
        }
    }

}
