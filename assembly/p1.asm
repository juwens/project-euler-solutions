; -----------------------------------------------------------------------------
; A 64-bit Linux application
;
;     nasm -felf64 p1.asm && gcc-5 p1.o -o p1 && ./p1
; -----------------------------------------------------------------------------

global  main
extern  printf


section .text

main: 
    mov     r12, 0  ; summe
    mov     r13, 0  ; increment
    mov     r14, 1000 ; max

loop:
    inc     r13

    cmp     r13, r14
    je     end
    
    ; % 3
    xor     rdx, rdx    ; clear rdx for Rest
    mov     rax, r13
    mov     rbx, 0x03
    idiv    rbx         ; rax / rbx => rax + rdx
    cmp     rdx, 0x00   ; Rest == 0?
    je      print
    
    ; % 5
    xor     rdx, rdx    ; clear rdx for Rest
    mov     rax, r13
    mov     rbx, 0x05
    idiv    rbx         ; rax / rbx => rax + rdx
    cmp     rdx, 0x00   ; Rest == 0?
    je      print

    jmp loop

print:
    add     r12, r13

    mov     rdi, format             ; set 1st parameter (format)
    mov     rsi, r12                 ; set 2nd parameter (current_number)
    xor     rax, rax                ; because printf is varargs

    call    printf                  ; printf(format, current_number)

    jmp loop    

end:
    ret
    
format:
        db  "%d", 10, 0