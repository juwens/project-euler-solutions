#include <time.h>
#include <stdio.h>

/* prototype */
long long collatz(void);

long long collatz(void)
{
    time_t start = clock();

    long long start_limit = (long) 1e6;
    long long max_row_len_start = 0;
    long long max_row_len = 0;


    for (long long current_start=2; current_start < start_limit; current_start++)
    {
        long long current_n = current_start;
        long long current_len = 0;
        while (current_n > 1) {
            current_len++;
            current_n = ((current_n&1) ==  0)
                    ? current_n >> 1
                    : current_n * 3 + 1;
        }

        if (current_len > max_row_len) {
            max_row_len = current_len;
            max_row_len_start = current_start;
        }
    }

    time_t end = clock();
	
    printf("answer: %lld, len: %lld\n", max_row_len_start, max_row_len);
    printf("time [ms]: %ld\n", (long) ((end - start) * 1000) / (CLOCKS_PER_SEC ));
	
	return (long long) end-start;
}

//int main(int argc, char *argv[])
int main(void)
{
#define rounds 10
	
	long long times_sum = 0;
	
	for (int i=0; i < rounds; i++) {
		times_sum += collatz();
	}
	
	printf("durchschnitliche zeit: %ld", (times_sum/rounds));
	
	// keep window open
	int c = getchar();
	printf("%c", c);
	
	return 0;
}