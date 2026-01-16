public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') { // checks if item is (, [, or {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(') // pops item, returns false if poped item is not ( or if stack count is 0
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[') // pops item, returns false if poped item is not [ or if stack count is 0
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{') // pops item, returns false if poped item is not { or if stack count is 0
                    return false;
            }
        }

        return stack.Count == 0;
    }
} // returns true if line contains no unclosed (), [], or {}. Returns false otherwise.