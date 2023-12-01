# Code Smells in Rocket Class

**1. Poor Naming Conventions**
- **Class Name:** `BaseRocket` (line 3)
  - Explanation: The class name `BaseRocket` does not describe the type of rocket it represents, which can be confusing.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G19%3A%20Use%20Explanatory%20Variables)
- **Variable:** `maxAlt` (line 5)
  - Explanation: The variable name `maxAlt` is abbreviated and not self-explanatory.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G16%3A%20Obscured%20Intent)
- **Variable:** `x` (line 7)
  - Explanation: The variable `x` is not descriptive and does not clearly indicate its purpose.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G19%3A%20Use%20Explanatory%20Variables)
- **Variable:** `MESSAGE` (line 8)
  - Explanation: The variable `MESSAGE` does not follow the same naming style as other variables, leading to inconsistency.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G11%3A%20Inconsistency)

**2. Encapsulation Violation**
- **Variable:** `altitude` (line 6)
  - Explanation: The `altitude` variable should be private or protected to prevent direct modification from outside the class.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G4%3A%20Overridden%20Safeties)

**3. Inappropriate Use of `virtual` Method**
- **Method:** `Launch` (line 9)
  - Explanation: This `virtual` method in the base class does not handle any logic but provides a default implementation, which is not ideal for a base class.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G6%3A%20Code%20at%20Wrong%20Level%20of%20Abstraction)

**4. Operator Overloading**
- **Method:** `operator +` (line 13)
  - Explanation: Overloading the `+` operator for `BaseRocket` does not have a clear benefit and can create confusion.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G2%3A%20Obvious%20Behavior%20Is%20Unimplemented)

**5. Method Design Issues**
- **Method:** `Launch` (line 22)
  - Explanation: The `Launch` method could be designed to take an argument for setting the height instead of directly setting to `maxAlt`.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=F1%3A%20Too%20Many%20Arguments)
- **Method:** `Launch` (line 22)
  - Explanation: The `Launch` method also could use with much less arguments that do not uniquely contribute to the methods functionality.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=Too%20Many%20Arguments)
- **Method:** `StallHelper` (line 47)
  - Explanation: This method is not called, therefore is completely useless.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=F4%3A%20Dead%20Function)
- **Method:** `Land` (line 51)
  - Explanation: The `Land` method does too much by landing the rocket and also resetting its state. Separation of concerns is not followed.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G30%3A%20Functions%20Should%20Do%20One%20Thing)
- **Method:** `CombineRockets` (line 57)
  - Explanation: This method is doing more than one thing—it combines rockets and also launches the new rocket.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G30%3A%20Functions%20Should%20Do%20One%20Thing)


**6. Magic Numbers and Lack of Constants**
- **Variable Assignment:** `altitude` (line 25)
  - Explanation: `altitude` is set to a hard-coded maximum value instead of using a constant, making the code less maintainable.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G25%3A%20Replace%20Magic%20Numbers%20with%20Named%20Constants)

**7. Rigidity**
- **Variable:** `combinedRocket` (line 76)
  - Explanation: The `CombineRockets` method only works with `Rocket` instances, not with instances of other types, even if they derived from `BaseRocket`.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G24%3A%20Follow%20Standard%20Conventions)

**8. Nested Dependencies**
- **Variable:** `isLaunched` (line 26)
  - Explanation: The variable `isLaunched` creates an unnecessary dependency, as other classes need to check the launched status. This tightly couples the classes.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G7%3A%20Base%20Classes%20Depending%20on%20Their%20Derivatives)

**9. Misuse of Control Structures**
- **Method:** `Stall` (line 33)
  - Explanation: The `Stall` method contains a confusing and unnecessarily complex chain of conditionals that could be simplified.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G2%3A%20Obvious%20Behavior%20Is%20Unimplemented)

**10. Redundant Code**
- **Unnecessary comments**  (line 9, 11)
  - Explanation: The comments `essential method` and `prints message` are either obsolute, or literally redundant. They are not helpful in any way.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=C3%3A%20Redundant%20Comment)
- **Variable Declaration:** `i` (line 31)
  - Explanation: The variable `i` is declared twice within the same scope, which is redundant and an error.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G5%3A%20Duplication)
- **Commented-out code**  (line 44)
  - Explanation: The code on line `44` is commented out, it will never run, so it should be removed.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=C5%3A%20Commented-Out%20Code)


