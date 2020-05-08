# Synopsis
The library collects some algorithms for quasiradnom number generation, published by [John Burkardt](https://people.sc.fsu.edu/~jburkardt/). This code is a conversion of Burkardt's code, which itself is partially based on Fortran code by Bennett Fox from ACM TOMS Algorithms, to C#. Sobol, Hammersley, Faure, Halton, and van der Corput sequences are implemented.

# Usage

## Iterating through a sequence

You can iterate through all sequences using the `Next` method.

```csharp
SobolSequence sobol = new SobolSequence(3);
for (int i=0; i < 1000: i++)
{
    double[] element = sobol.Next();
    // ...
}
```

### Constructor arguments

* Van der Corput sequence takes an optional index at which the iteration shall start.
```csharp
var sequence = new VanDerCorputSequence(27);
```

* Halton and Sobol sequences take the number of dimensions and an optional index.
```csharp
var sequence = new HaltonSequence(3, 27); // 3 dimensions, skip the first 27 elements
```

* Faure sequence takes the number of dimensions and optionally either an index or a flag indicating whether to skip a reco
```csharp
var sequence = new FaureSequence(3, false); // 3 dimensions, do not skip initial part of sequence
```

* Hammersley sequence takes the number of dimensions and the "base" for the first component and  optionally an index.
```csharp
var sequence = new HammersleySequence(3, 16); // 3 dimensions, "base" 16, no initial skip
```

## Direct calculation

The van der Corput, Halton, and Hammerley sequences allow calculating the element at a specified index without iterating through the sequence.

```csharp
int dimensions = 3;
int index = 10;
double[] element = HaltonSequence.GetElement(dimensions, index); // element == { 0.3125, 0.37037, 0.08 }
```

### Inversion

The `Invert` method allows getting the index of an element in a sequence. Note: Only the first component (base 2) is used for the inversion of a multui-dimensional element.

```csharp
double value = 0.0625;
int index = VanDerCorputSequence.Invert(value); //  // index == 8
```
```csharp
double[] element = new double[] { 0.375, 0.222222, 0.24 };
int index = HaltonSequence.Invert(element); // index == 6
```

# License

The code is distributed under the [GNU LGPL license](https://www.gnu.org/licenses/lgpl-3.0.en.html).

# References

* Bennett Fox: Algorithm 647: Implementation and Relative Efficiency of Quasirandom  Sequence Generators, ACM Transactions on Mathematical Software, Volume 12, Number 4, December 1986, pages 362-376.
* Paul Bratley, Bennett Fox: Algorithm 659: Implementing Sobol's Quasirandom Sequence Generator, ACM Transactions on Mathematical Software, Volume 14, Number 1, pages 88-100, 1988.
* Stephen Joe, Frances Kuo: Remark on Algorithm 659: Implementing Sobol's Quasirandom Sequence Generator, ACM Transactions on Mathematical Software, Volume 29, Number 1, pages 49-57, March 2003.
* IA Antonov, VM Saleev:  An Economic Method of Computing LP Tau-Sequences, USSR Computational Mathematics and Mathematical Physics, Volume 19, 1980, pages 252 - 256.
* Ilya Sobol, USSR Computational Mathematics and Mathematical Physics, Volume 16, pages 236-242, 1977.
* Ilya Sobol, YL Levitan: The Production of Points Uniformly Distributed in a Multidimensional  Cube (in Russian), Preprint IPM Akad. Nauk SSSR, Number 40, Moscow 1976.
* John Hammersley: Monte Carlo methods for solving multivariable problems, Proceedings of the New York Academy of Science, Volume 86, 1960, pages 844-874.
