   M S B A M L   `   `   `  ���� G  CMonopolyDeal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:MonopolyDealMonopolyDeal      MonopolyDeal.playerTurn   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     ,localclr-namespace:MonopolyDeal     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     -     �Name$  window�� � Title$ 
playerTurn�� � WindowStartupLocation$ CenterScreen=� � WindowState$ 	Maximized=�$
��Auto��.��� -    �Name$
 grid��.+��� -    ��Name$ button1��$��Button��$
��Left=�$��145,266,0,0q�$	��Top=�$	��140��$��43�����	#FF7F74C7�� -   $ button2��$��Button��$
��Left=�$��326,266,0,0q�$	��Top=�$	��144��$��43�����	#FF7F74C7�� -   $ button3��$��Button��$
��Left=�$��503,266,0,0q�$	��Top=�$	��144��$��43�����	#FF7F74C7�� -    ��Name$
 Hand��$
��Left=�$	��189��$��	10,71,0,0q�$	��Top=�$	��194�� �� AlternationCount$ 5��|�.  �� -   $ Table_Properties��$
��Left=�$	��189��$��
228,71,0,0q�$	��Top=�$	��201��$ 5��|�.  �� -   $ 
buttonBack��$��Go Back��$
��Left=�$��
26,272,0,0q�$	��Top=�$��80��$��31�����	#FFEC1515�� -	   $ Table_Money��$
��Left=�$	��188��$��
468,71,0,0q�$	��Top=�$	��194��$ 5��|�.  �� -
    ��Name$ propertiesLabel��$
��Left=�$��19��$��
244,47,0,0q�	 �� TextWrapping$
	 Wrap=�$��Properties:��$	��Top=�$	��110���� -   $ 
moneyLabel��$
��Left=�$��19��$��
480,47,0,0q�$
	 Wrap=�$��Money:��$	��Top=�$��56���� -   $ buttonPlayer��$��Button��$
��Left=�$��	10,10,0,0q�$	��Top=�$��91��$��32�����	#FF53C11F�� -   
 ��Name$
 deckCountDisplay��$�� ��$
��Left=�$��	631,4,0,0q�$	��Top=�$��31��$��32��$��0q�$��0q��� -    ��Name$ cardsLeftText��$
��Left=�$��	570,4,0,0q�$
��Wrap=�$��Cards In Deck��$	��Top=�$��32��$��56���� -   $
 turnsLeftDisplay��$�� ��$
��Left=�$��
631,38,0,0q�$	��Top=�$��31��$��32��$��0q�$��0q��� -   $ turnsLeftText��$
��Left=�$��
570,47,0,0q�$
��Wrap=�$��
Turns Left��$	��Top=�$��19��$��56���� -   $
 Prompt��$�� ��$
��Left=�$��
106,10,0,0q�$	��Top=�$��32��$	��438��$��1q�
���   ���. $��Visible=��� -   $ 	handLabel��$
��Left=�$��19��$��	10,46,0,0q�$
	 Wrap=�$��Hand:��$	��Top=�$	��110�� J� 	AllowDrop .  �� -   $ universalPrompt��$
��Left=�$��23��$��851,119,0,0q�$
	 Wrap=�$	��Top=�$	��120��
���   �$ �� HorizontalScrollBarVisibility$
 Auto=���. " �� VerticalScrollBarVisibility$
 Auto=� �� 
IsReadOnly . 