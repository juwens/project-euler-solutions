// gcc-5  p1.c -o p1 && ./p1
// gcc -mtune=generic -march=x86-64 -O2 -fverbose-asm -S p1.c -o p1_gcc.s && cat p1_gcc.s

// llvm
// clang -O2 p1.c -S  -o p1_clang.s && cat p1_clang.s

// http://gcc.godbolt.org/

#include <stdio.h>

int main()  {
    int sum = 0;
    
    for (int i=0; i<1000; i++) {
        if (i%3 == 0 || i%5 == 0) {
            printf("%d\n", i);
            sum += i;
        }
    }
    
    printf("sum: %d\n", sum);
    
    return 0;
}