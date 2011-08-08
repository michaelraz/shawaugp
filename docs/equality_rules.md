#Rules for framework equality checking

1. Is it a class (reference type)
  * Does the type implement IEquatable<T> for itself - use it
  * Does the type override the Equals method - use it
  * Reference based equality check

2. Is it a struct (value type)
  * Does the type override the Equals method - use it
  * Reflective field by field equality comparison
