<?php

function collatz() {
    $start = microtime(true);

    $start_limit = 1e6;
    $max_row_len_start = 0;
    $max_row_len = 0;


    for ($current_start = 2; $current_start < $start_limit; $current_start++) {
        $current_n = $current_start;
        $current_len = 0;
        while ($current_n > 1) {
            $current_len++;
            $current_n = (($current_n & 1) == 0) ? $current_n >> 1 : $current_n * 3 + 1;
        }

        if ($current_len > $max_row_len) {
            $max_row_len = $current_len;
            $max_row_len_start = $current_start;
        }
    }

    $end = microtime(true);

    printf("answer: " . $max_row_len_start . ", len: " . $max_row_len . PHP_EOL);
    printf("time [ms]: " . ($end - $start) * 1000 . PHP_EOL);
}

collatz();