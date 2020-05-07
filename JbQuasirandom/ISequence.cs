namespace JbQuasirandom
{
    /// <summary>A sequence of numbers.</summary>
    public interface ISequence
    {
        /// <summary>Gets the next element of the sequence.</summary>
        /// <returns>The next element of the sequence.</returns>
        double[] Next();
    }
}
