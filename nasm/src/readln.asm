    global _start
    extern  _GetStdHandle@4
    extern  _WriteFile@20
    extern  _ExitProcess@4
	extern  _Beep@8
	extern	_ReadConsoleA@20
	extern	_printf

section .bss           ;Uninitialized data
	str:	resw 80
	len:	resd 1
	rez:	resd 10
	
segment .data
	msg		db 'Hi C', 10, 0
	format	db "%d", 10, 0
	
segment .text
_start:
    ; DWORD  bytes;    
    mov     ebp, esp
    sub     esp, 4

    ; hStdOut = GetstdHandle( STD_OUTPUT_HANDLE)
    push    -11
    call    _GetStdHandle@4
    mov     ebx, eax

    ; WriteFile(hstdOut, message, length(message), &bytes, 0);
    push    0
    lea     eax, [ebp-4]
    push    eax
    push    (message_end - message)
    push    message
    push    ebx
    call    _WriteFile@20
	
	; hStdOut = GetstdHandle( STD_OUTPUT_HANDLE)
    push    -10
    call    _GetStdHandle@4
	mov     ecx, eax
	
	;ReadConsole: procedure (hConsoleInput: dword; lpBuffer: var; nNumberOfCharsToRead: dword; lpNumberOfCharsRead: dword; lpReserved: var );
	push	0
	push	len
	push	dword 100
	push	str
	push	ecx
	call	_ReadConsoleA@20
	
	push	dword [len]
	push	format
	call	_printf
	pop 	edx
	
	mov 	edx, [len]
	mov		dword [rez], edx
	add 	dword [rez], '0'
	add 	dword [rez + 1], '0'
	add 	dword [rez + 2], '0'
	add 	dword [rez + 3], '0'
	mov 	byte [rez + 9], 10
	; WriteFile(hstdOut, message, length(message), &bytes, 0);
    push    0
	 lea	eax, [ebp-4]
    push    eax
    push    10
    push    rez
    push    ebx
    call    _WriteFile@20
	; WriteFile(hstdOut, message, length(message), &bytes, 0);
    push    0
	 lea	eax, [ebp-4]
    push    eax
    push    10
    push    str
    push    ebx
    call    _WriteFile@20
	
	; WriteFile(hstdOut, message, length(message), &bytes, 0);
    ;push    0
    ;lea     eax, [ebp-4]
    ;push    eax
    ;push    len
    ;push    str
    ;push    ebx
    ;call    _WriteFile@20

    ; ExitProcess(0)
    push    0
    call    _ExitProcess@4

    ; never here
    hlt
message:
    db      'Write line', 10
message_end:
