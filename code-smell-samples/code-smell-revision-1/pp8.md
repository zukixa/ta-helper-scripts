# Code Smells in Inventory Class

**1. Excessive Class Size**
- **Class:** `Inventory` (line 3)
  - Explanation: The `Inventory` class is trying to manage quantities, discounts, and user types, which might indicate that it is handling multiple responsibilities that could be better separated into different classes or methods.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G34%3A%20Functions%20Should%20Descend%20Only%20One%20Level%20of%20Abstraction)

**2. Contingent States**
- **Variable:** `discountQuantity` (line 6)
  - Explanation: This variable implies that the presence of a discount is contingent on the value of `quantity`, which can lead to a state in which the logic of discounts is not explicit or clear, even more so as discountQuantity is not used.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G11%3A%20Inconsistency)

**3. Stringly-Typed Code**
- **Variable:** `USER_TYPE` (line 8)
  - Explanation: The use of strings to represent user types is less robust than using more structured data types like enumerations, which can help avoid errors caused by typos and can make the code easier to refactor.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G2%3A%20Obvious%20Behavior%20Is%20Unimplemented)

**4. Implicit Conversion of Critical State**
- **Variable Assignment:** `quantity = 0;` (line 15 & 32)
  - Explanation: Setting `quantity` to `0` when it exceeds `MAX_QUANTITY` might represent a special state in the system that should not be implicitly converted but handled explicitly.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G3%3A%20Incorrect%20Behavior%20at%20the%20Boundaries)

**5. Avoid negative conditionals**
- **Statement:** `if (!(quantity < MAX_QUANTITY))` (line 13)
  - Explanation: Negative conditionals are usually harder to understand, and this one specifically can be simplified by simply using a `>`
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G29%3A%20Avoid%20Negative%20Conditionals)

**6. Inconsistent Method Overloading**
- **Method:** `Increase(string amount, string discount)` (line 18)
  - Explanation: Overloading the `Increase` method without a clear differentiation between the two versions can be confusing and does not follow the principle of least astonishment.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=N1%3A%20Choose%20Descriptive%20Names)

**7. Discontinuous Control Flow**
- **Statement:** `goto specialLabel;` (line 20)
  - Explanation: The use of `goto` leads to discontinuous control flow, making the code harder to read and maintain.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G4%3A%20Overridden%20Safeties)

**8. Duplicated Code**
- **Code Block:** (line 23-33)
  - Explanation: The code that checks for `MAX_QUANTITY` and sets `quantity` to `0` is duplicated from the other `Increase` method, which violates the DRY (Don't Repeat Yourself) principle.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G5%3A%20Duplication)

**9. Large Switch Case Blocks**
- **Method:** `CheckQuantityStatus` (line 36)
  - Explanation: The method contains a large switch statement that could potentially be replaced with a dictionary lookup or another strategy that scales better with more cases.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G23%3A%20Prefer%20Polymorphism%20to%20If%2FElse%20or%20Switch%2FCase)

**10. Lack of Inline Assertions**
- **Statement:** `Console.WriteLine("We reached max quantity. Set to zero");` (line 15 & 32)
  - Explanation: The lack of assertions or error handling after setting the `quantity` to `0` indicates a missed opportunity to enforce invariants within the code.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G3%3A%20Incorrect%20Behavior%20at%20the%20Boundaries)

**11. Lack of Error Handling**
- **Method:** `Increase(string amount)` (line 12)
  - Explanation: Parsing the string `amount` directly without checking for conversion errors can lead to runtime exceptions if the string cannot be parsed into an integer.
  - [Link to further explanation](https://learning.oreilly.com/library/view/clean-code-a/9780136083238/chapter17.xhtml#:-:text=G3%3A%20Incorrect%20Behavior%20at%20the%20Boundaries)
