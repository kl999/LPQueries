extern ExitProcess                          ;windows API function to exit process
extern WriteConsoleA                        ;windows API function to write to the console window (ANSI version)
extern ReadConsoleA                         ;windows API function to read from the console window (ANSI version)
extern GetStdHandle                         ;windows API to get the for the console handle for input/output

section .data                               ;the .data section is where variables and constants are defined

STD_OUTPUT_HANDLE   equ -11
STD_INPUT_HANDLE    equ -10

digits      db      '0123456789'            ;list of digits

input_message db   'Please enter your next number: '
length equ $-input_message

NULL        equ     0

section .bss                                ;the .bss section is where space is reserved for additional variables

input_buffer:   resb 3                      ;reserve 64 bits for user input

char_written:   resb    4
chars:   resb 4                             ;reversed for use with write operation

section .text                               ;the .text section is where the program code goes

global _main                                ;tells the machine which label to start program execution from

_num_to_str:
        sub rsp, 32
        cmp rax, 0
        jne .next_digit
        push rax
        inc r15
        jmp .output
.next_digit:
        cmp rax, 0                          ;compare value in rax to 0
        jne .convert                        ;if not equal then jump to label
        jmp .output

.convert:
        ;get next digit value
        inc r15                             ;increment the counter for next digit

        mov rcx, 10
        xor rdx, rdx                        ;clear previous remainder result
        div rcx                             ;divide value in rax by value in rcx
                                            ;quotient (result) stored in rax
                                            ;remainder stored in rdx

        sub rsp, 8                          ;add space on stack for value
        push rdx                            ;store remainder on the stack

        jmp .next_digit

.output:
        pop rdx                             ;get the last digit from the stack
        add rsp, 8                          ;remove space from stack for popped value

        ;convert digit value to ascii character
        mov r10, digits                     ;load the address of the digits into rsi
        add r10, rdx                        ;get the character of the digits string to display

        mov rdx, r10                        ;digit to print
        mov r8, 1                           ;one byte to be output

        call _print

        ;decide whether to loop
        dec r15                             ;reduce remaining digits (having printed one)
        cmp r15, 0                          ;are there digits left to print?
        jne .output                          ;if not equal then jump to label output
        add rsp, 32
        ret

_print:
        sub rsp, 40
        ;get the output handle
        mov rcx, STD_OUTPUT_HANDLE          ;specifies that the output handle is required
        call GetStdHandle                   ;returns value for handle to rax

        mov rcx, rax
        mov r9, char_written

        mov rax, qword 0                    ;fifth argument
        mov qword [rsp+0x20], rax

        call WriteConsoleA
        add rsp, 40
        ret

_read:
        sub rsp, 40
        ;get the input handle
        mov rcx, STD_INPUT_HANDLE           ;specifies that the input handle is required
        call GetStdHandle

        ;get value from keyboard
        mov rcx, rax                        ;place the handle for operation
        xor rdx, rdx
        mov rdx, input_buffer               ;set name to receive input from keyboard



        mov r8, 3                           ;max number of characters to read
        mov r9, chars                       ;stores the number of characters actually read

        mov rax, qword 0                    ;fifth argument
        mov qword [rsp+0x20], rax

        call ReadConsoleA


        movzx r12, byte[input_buffer]
        add rsp, 40
        ret

_get_value:
        sub rsp, 40

        mov rdx, input_message              ;move the input message into rdx for function call
        mov r8, length                      ;load the length of the message for function call

        call _print
        call _read
.end:
        add rsp, 40
        ret

_main:
        sub rsp, 40
        mov r13, 0                          ;counter for values input
        mov r14, 0                          ;total for calculation
.loop:
        call _get_value                     ;get value from user

        sub r12, '0'                        ;convert char to integer
        add r14, r12                        ;add value to total

        ;decide whether to loop for another character or not
        inc r13
        cmp r13, 2
        jne .loop

        ;convert total to ASCII value

        mov rax, r14                             ;num_to_str expects total in rax

        mov r15, 0                               ;num_to_str uses r15 as a counter - must be initialised
        call _num_to_str

        ;exit the program
        mov rcx, 0                          ;exit code

        call ExitProcess
        add rsp, 40
        ret