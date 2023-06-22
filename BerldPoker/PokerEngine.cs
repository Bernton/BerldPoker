using System;
using System.Collections.Generic;
using System.Linq;

namespace BerldPoker
{
    public static class PokerEngine
    {
        public static int Total
        {
            get
            {
                return
                    StraightFlush +
                    FourOfAKind +
                    FullHouse +
                    Flush +
                    Straight +
                    ThreeOfAKind +
                    TwoPair +
                    Pair +
                    HighCard;
            }
        }

        public static int RoyalFlush { get; private set; }
        public static int StraightFlush { get; private set; }
        public static int FourOfAKind { get; private set; }
        public static int FullHouse { get; private set; }
        public static int Flush { get; private set; }
        public static int Straight { get; private set; }
        public static int ThreeOfAKind { get; private set; }
        public static int TwoPair { get; private set; }
        public static int Pair { get; private set; }
        public static int HighCard { get; private set; }

        public static IHandValue[] GetWinnerValues(IHandValue[] handValues)
        {
            if (handValues == null || handValues.Length < 2)
            {
                throw new ArgumentException("HandValues may not be null and have to more than 2 to compare");
            }

            IHandValue currentlyLeading = handValues[0];
            List<IHandValue> sameAsLead = new List<IHandValue>();

            for (int i = 1; i < handValues.Length; i++)
            {
                if (IsCompetitorStronger(currentlyLeading, handValues[i], sameAsLead))
                {
                    currentlyLeading = handValues[i];
                    sameAsLead.Clear();
                }
            }

            sameAsLead.Add(currentlyLeading);
            return sameAsLead.ToArray();
        }

        public static bool IsCompetitorStronger(IHandValue currentlyBest, IHandValue competitor, List<IHandValue> toAddSame)
        {
            if (currentlyBest.GetRank() < competitor.GetRank())
            {
                return false;
            }
            else if (currentlyBest.GetRank() > competitor.GetRank())
            {
                return true;
            }
            else
            {
                Type type = currentlyBest.GetType();

                if (type == typeof(StraightFlush))
                {
                    if (((StraightFlush)currentlyBest).Highest > ((StraightFlush)competitor).Highest)
                    {
                        return false;
                    }
                    else if (((StraightFlush)currentlyBest).Highest < ((StraightFlush)competitor).Highest)
                    {
                        return true;
                    }
                    else
                    {
                        toAddSame.Add(competitor);
                        return false;
                    }
                }
                else if (type == typeof(FourOfAKind))
                {
                    if (((FourOfAKind)currentlyBest).Value > ((FourOfAKind)competitor).Value)
                    {
                        return false;
                    }
                    else if (((FourOfAKind)currentlyBest).Value < ((FourOfAKind)competitor).Value)
                    {
                        return true;
                    }
                    else
                    {
                        if (((FourOfAKind)currentlyBest).Kicker > ((FourOfAKind)competitor).Kicker)
                        {
                            return false;
                        }
                        else if (((FourOfAKind)currentlyBest).Kicker < ((FourOfAKind)competitor).Kicker)
                        {
                            return true;
                        }
                        else
                        {
                            toAddSame.Add(competitor);
                            return false;
                        }
                    }
                }
                else if (type == typeof(FullHouse))
                {
                    if (((FullHouse)currentlyBest).ThreeOfAKind > ((FullHouse)competitor).ThreeOfAKind)
                    {
                        return false;
                    }
                    else if (((FullHouse)currentlyBest).ThreeOfAKind < ((FullHouse)competitor).ThreeOfAKind)
                    {
                        return true;
                    }
                    else
                    {
                        if (((FullHouse)currentlyBest).Pair > ((FullHouse)competitor).Pair)
                        {
                            return false;
                        }
                        else if (((FullHouse)currentlyBest).Pair < ((FullHouse)competitor).Pair)
                        {
                            return true;
                        }
                        else
                        {
                            toAddSame.Add(competitor);
                            return false;
                        }
                    }
                }
                else if (type == typeof(Flush))
                {
                    for (int i = 0; i < ((Flush)currentlyBest).Values.Length; i++)
                    {
                        if (((Flush)currentlyBest).Values[i] > ((Flush)competitor).Values[i])
                        {
                            return false;
                        }
                        else if (((Flush)currentlyBest).Values[i] < ((Flush)competitor).Values[i])
                        {
                            return true;
                        }
                    }

                    toAddSame.Add(competitor);
                    return false;
                }
                else if (type == typeof(Straight))
                {
                    if (((Straight)currentlyBest).Highest > ((Straight)competitor).Highest)
                    {
                        return false;
                    }
                    else if (((Straight)currentlyBest).Highest < ((Straight)competitor).Highest)
                    {
                        return true;
                    }
                    else
                    {
                        toAddSame.Add(competitor);
                        return false;
                    }
                }
                else if (type == typeof(ThreeOfAKind))
                {
                    if (((ThreeOfAKind)currentlyBest).Value > ((ThreeOfAKind)competitor).Value)
                    {
                        return false;
                    }
                    else if (((ThreeOfAKind)currentlyBest).Value < ((ThreeOfAKind)competitor).Value)
                    {
                        return true;
                    }
                    else
                    {
                        if (((ThreeOfAKind)currentlyBest).Kickers[0] > ((ThreeOfAKind)competitor).Kickers[0])
                        {
                            return false;
                        }
                        else if (((ThreeOfAKind)currentlyBest).Kickers[0] < ((ThreeOfAKind)competitor).Kickers[0])
                        {
                            return true;
                        }
                        else
                        {
                            if (((ThreeOfAKind)currentlyBest).Kickers[1] > ((ThreeOfAKind)competitor).Kickers[1])
                            {
                                return false;
                            }
                            else if (((ThreeOfAKind)currentlyBest).Kickers[1] < ((ThreeOfAKind)competitor).Kickers[1])
                            {
                                return true;
                            }
                            else
                            {
                                toAddSame.Add(competitor);
                                return false;
                            }
                        }
                    }
                }
                else if (type == typeof(TwoPair))
                {
                    if (((TwoPair)currentlyBest).HigherPair > ((TwoPair)competitor).HigherPair)
                    {
                        return false;
                    }
                    else if (((TwoPair)currentlyBest).HigherPair < ((TwoPair)competitor).HigherPair)
                    {
                        return true;
                    }
                    else
                    {
                        if (((TwoPair)currentlyBest).LowerPair > ((TwoPair)competitor).LowerPair)
                        {
                            return false;
                        }
                        else if (((TwoPair)currentlyBest).LowerPair < ((TwoPair)competitor).LowerPair)
                        {
                            return true;
                        }
                        else
                        {
                            if ((((TwoPair)currentlyBest).Kicker > ((TwoPair)competitor).Kicker))
                            {
                                return false;
                            }
                            else if ((((TwoPair)currentlyBest).Kicker < ((TwoPair)competitor).Kicker))
                            {
                                return true;
                            }
                            else
                            {
                                toAddSame.Add(competitor);
                                return false;
                            }
                        }
                    }
                }
                else if (type == typeof(Pair))
                {
                    if (((Pair)currentlyBest).Value > ((Pair)competitor).Value)
                    {
                        return false;
                    }
                    else if (((Pair)currentlyBest).Value < ((Pair)competitor).Value)
                    {
                        return true;
                    }
                    else
                    {
                        for (int i = 0; i < ((Pair)currentlyBest).Kickers.Length; i++)
                        {
                            if (((Pair)currentlyBest).Kickers[i] > ((Pair)competitor).Kickers[i])
                            {
                                return false;
                            }
                            else if (((Pair)currentlyBest).Kickers[i] < ((Pair)competitor).Kickers[i])
                            {
                                return true;
                            }
                        }

                        toAddSame.Add(competitor);
                        return false;
                    }
                }
                else
                {
                    for (int i = 0; i < ((HighCard)currentlyBest).Values.Length; i++)
                    {
                        if (((HighCard)currentlyBest).Values[i] > ((HighCard)competitor).Values[i])
                        {
                            return false;
                        }
                        else if (((HighCard)currentlyBest).Values[i] < ((HighCard)competitor).Values[i])
                        {
                            return true;
                        }
                    }

                    toAddSame.Add(competitor);
                    return false;
                }
            }
        }

        public static IHandValue GetHandValue(Card[] cards)
        {
            IHandValue handValue = null;

            if (IsStraightFlush(cards, ref handValue))
            {
                if (((StraightFlush)handValue).Highest == CardRank.Ace)
                {
                    RoyalFlush++;
                }

                StraightFlush++;
                return handValue;
            }

            if (IsFourOfAKind(cards, ref handValue))
            {
                FourOfAKind++;
                return handValue;
            }

            if (IsFullHouse(cards, ref handValue))
            {
                FullHouse++;
                return handValue;
            }

            if (IsFlush(cards, ref handValue))
            {
                Flush++;
                return handValue;
            }

            if (IsStraight(cards, ref handValue))
            {
                Straight++;
                return handValue;
            }

            if (IsThreeOfAKind(cards, ref handValue))
            {
                ThreeOfAKind++;
                return handValue;
            }

            if (IsTwoPair(cards, ref handValue))
            {
                TwoPair++;
                return handValue;
            }

            if (IsPair(cards, ref handValue))
            {
                Pair++;
                return handValue;
            }


            HighCard++;
            Card[] sorted = cards.OrderBy(c => c.Rank).ToArray();
            CardRank[] best5 = new CardRank[]
            {
                sorted[6].Rank,
                sorted[5].Rank,
                sorted[4].Rank,
                sorted[3].Rank,
                sorted[2].Rank
            };

            return new HighCard(best5);
        }

        private static bool IsStraightFlush(Card[] cards, ref IHandValue value)
        {
            for (int i = 0; i < 4; i++)
            {
                Card[] result = cards.Where(c => c.Suit == ((CardSuit)i)).OrderBy(c => c.Rank).ToArray();

                if (result.Length >= 5 && IsStraight(result, ref value))
                {
                    value = new StraightFlush(((Straight)value).Highest);
                    return true;
                }
            }

            return false;
        }

        private static bool IsFourOfAKind(Card[] cards, ref IHandValue value)
        {
            for (int i = 0; i < 13; i++)
            {
                if (cards.Where(c => c.Rank == ((CardRank)i)).ToArray().Length == 4)
                {
                    CardRank kicker = cards.Where(c => c.Rank != (CardRank)i).Max(c => c.Rank);

                    value = new FourOfAKind((CardRank)i, kicker);
                    return true;
                }
            }

            return false;
        }

        private static bool IsFullHouse(Card[] cards, ref IHandValue value)
        {
            int? threeOfAKindIndex = null;

            for (int i = 12; i >= 0; i--)
            {
                if (cards.Where(c => c.Rank == ((CardRank)i)).ToArray().Length == 3)
                {
                    threeOfAKindIndex = i;
                    break;
                }
            }

            if (!threeOfAKindIndex.HasValue)
            {
                return false;
            }

            for (int i = 12; i >= 0; i--)
            {
                if (i == threeOfAKindIndex)
                {
                    continue;
                }

                if (cards.Where(c => c.Rank == ((CardRank)i)).ToArray().Length >= 2)
                {
                    value = new FullHouse((CardRank)threeOfAKindIndex.Value, (CardRank)i);
                    return true;
                }
            }

            return false;
        }

        private static bool IsFlush(Card[] cards, ref IHandValue value)
        {
            for (int i = 0; i < 4; i++)
            {
                Card[] result = cards.Where(c => c.Suit == ((CardSuit)i)).OrderBy(c => Math.Abs((int)c.Rank - 12)).ToArray();

                if (result.Length >= 5)
                {
                    value = new Flush(new CardRank[]
                    {
                        result[0].Rank,
                        result[1].Rank,
                        result[2].Rank,
                        result[3].Rank,
                        result[4].Rank
                    });

                    return true;
                }
            }

            return false;
        }

        private static bool IsStraight(Card[] cards, ref IHandValue value)
        {
            List<Card> listCards = cards.ToList();
            listCards = listCards.OrderBy(c => c.Rank).ToList();

            int consec = 1;

            if (listCards[listCards.Count - 1].Rank == CardRank.Ace && listCards[0].Rank == CardRank.Deuce)
            {
                consec = 2;
            }

            for (int i = 1; i < listCards.Count; i++)
            {
                if (listCards[i].Rank == listCards[i - 1].Rank)
                {
                    continue;
                }

                if ((int)(listCards[i].Rank - 1) == (int)listCards[i - 1].Rank)
                {
                    consec++;
                }
                else
                {
                    consec = 1;
                }

                if (consec >= 5)
                {
                    if (i != listCards.Count - 1 && listCards[i].Rank + 1 == listCards[i + 1].Rank)
                    {
                        continue;
                    }

                    value = new Straight(listCards[i].Rank);
                    return true;
                }
            }

            return false;
        }

        private static bool IsThreeOfAKind(Card[] cards, ref IHandValue value)
        {
            for (int i = 0; i < 13; i++)
            {
                if (cards.Where(c => c.Rank == ((CardRank)i)).ToArray().Length == 3)
                {
                    Card[] result = cards.Where(c => c.Rank != ((CardRank)i)).OrderBy(c => Math.Abs((int)c.Rank - 12)).ToArray();

                    value = new ThreeOfAKind((CardRank)i, new CardRank[]
                    {
                        result[0].Rank,
                        result[1].Rank
                    });

                    return true;
                }
            }

            return false;
        }

        private static bool IsTwoPair(Card[] cards, ref IHandValue value)
        {
            int countOfPairs = 0;
            int higherPair = 0;
            int lowerPair = 0;

            for (int i = 0; i < 13; i++)
            {
                if (cards.Where(c => c.Rank == ((CardRank)i)).ToArray().Length == 2)
                {
                    countOfPairs++;
                    lowerPair = higherPair;
                    higherPair = i;
                }
            }

            if (countOfPairs >= 2)
            {
                CardRank kicker = cards.Where(c => (int)c.Rank != higherPair && (int)c.Rank != lowerPair).Max(c => c.Rank);

                value = new TwoPair((CardRank)higherPair, (CardRank)lowerPair, kicker);
                return true;
            }

            return false;
        }

        private static bool IsPair(Card[] cards, ref IHandValue value)
        {
            for (int i = 0; i < 13; i++)
            {
                Card[] result = cards.Where(c => c.Rank == ((CardRank)i)).ToArray();

                if (result.Length == 2)
                {
                    Card[] sorted = cards.Where(c => c.Rank != ((CardRank)i)).OrderBy(c => Math.Abs((int)c.Rank - 12)).ToArray();

                    value = new Pair((CardRank)i, new CardRank[]
                    {
                        sorted[0].Rank,
                        sorted[1].Rank,
                        sorted[2].Rank
                    });

                    return true;
                }
            }

            return false;
        }
    }
}
