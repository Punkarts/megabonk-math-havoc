namespace MegabonkMathHavoc.Core
{
    /// <summary>Pure arithmetic only; does not hook or launch either game.</summary>
    public static class BonusRules
    {
        public static decimal Settle(decimal currentMultiplier, int correctAnswers,
            decimal gainPerAnswer, bool wrongAnswer)
        {
            if (currentMultiplier < 0m)
                throw new System.ArgumentOutOfRangeException(nameof(currentMultiplier));
            if (correctAnswers < 0)
                throw new System.ArgumentOutOfRangeException(nameof(correctAnswers));
            if (gainPerAnswer < 0m)
                throw new System.ArgumentOutOfRangeException(nameof(gainPerAnswer));
            decimal total = currentMultiplier + correctAnswers * gainPerAnswer;
            return wrongAnswer ? total / 2m : total;
        }
    }
}
