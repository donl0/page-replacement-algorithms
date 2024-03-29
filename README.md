# Page replacement algorithms in operating Systems by c#

## Replacement algorithms

- [FIFO](https://github.com/donl0/page-replacement-algorithms/blob/main/Application/Replacer/FIFOReplacer.cs)
- [LRU](https://github.com/donl0/page-replacement-algorithms/blob/main/Application/Replacer/LRUReplacer.cs)
- [Optimal](https://github.com/donl0/page-replacement-algorithms/blob/main/Application/Replacer/OptimalReplacer.cs)
  
## Output

- [Logger](https://github.com/donl0/page-replacement-algorithms/tree/main/ConsoleUI/Logger)
- Substitute another in [builder](https://github.com/donl0/page-replacement-algorithms/blob/main/ConsoleUI/Builder/AlgorithmBuilder.cs) if you need.

## How to run

[ConsoleUI](https://github.com/donl0/page-replacement-algorithms/tree/main/ConsoleUI) layer is also an sturtup project. His responsability is UI.
[Entry point](https://github.com/donl0/page-replacement-algorithms/blob/main/ConsoleUI/Program.cs) with custom input values.

[algorithms](https://github.com/donl0/page-replacement-algorithms/blob/main/Domain/Interfaces/Replacer/PageReplacer.cs) takes List of adressing order and current primary memory(always empty in my case)
