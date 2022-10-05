# Homework Math Solver
A general maths solver of some problems, focusing on differentiation.

# Capabilities
Holds the ability to create homework question files, and has partial automated marking on differenation question. Is capable of limited multivariable calculus.

A general flow involves two parties, a teacher and a collection of students. The teacher will create either randomly generated question sets, or their own
from a set of question types. There is a heavy emphasis on differenation. It also has the ability to simplify fraction addition, 
and expand the brackets to further simplify any common elements.

![image](https://user-images.githubusercontent.com/26233238/194129304-9123b230-e71d-49de-b129-b2b165548450.png)

It is capable of most simplification methods, involving addition, fraction manipulation, and bracket expansion. It is designed to follow the fundamentals of calculus, 
meaning the idea of 'top-down term differenation' is upheld. It essentially means to follow the ideal that any term, such as (x^4+2x^3)^5, can be ambiguated as a^5,
and evaluated top down with a as a simple term. 

Moreso, d(a^5) = 5*a^4*da -> da = (da/dx) * dx, which is just chain rule.

I have also added fractional differenation, but this is a trivial modification of products.

# Future Capabilities 

If I add functions, most importantly including e and ln, I will be able to differentiate complex powers. It would also be plausible to 
include every other differentiable function, like trigometric functions or their hyperbolic counterparts. 

