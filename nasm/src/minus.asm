    global _start
    extern  _GetStdHandle@4
    extern  _WriteFile@20
    extern  _ExitProcess@4
	extern  _Beep@8

segment .bss
	rez:	resd 11

segment .data
	msg 	db 'Hello world!'
	msg2	db '            '
	
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
    push    (two_end - two)
    push    two
    push    ebx
    call    _WriteFile@20
	
	mov 	ecx, 3
	add		ecx, 2
	mov		dword [rez], 48
	add 	ecx, 48
	mov		dword [rez + 8], ecx
	mov		dword [rez + 9], 10
	
	; WriteFile(hstdOut, message, length(message), &bytes, 0);
    push    0
	 lea     eax, [ebp-4]
    push    eax
    push    10
    push    rez
    push    ebx
    call    _WriteFile@20
	
	mov 	edx, [msg]
	mov 	dword [rez],  edx
	mov 	edx, [msg + 4]
	mov 	dword [rez + 4],  edx
	mov 	edx, [msg + 8]
	mov 	dword [rez + 8],  edx
	;mov 	dword [rez], 'Zxcv'
	
	; WriteFile(hstdOut, message, length(message), &bytes, 0);
    push    0
	 lea     eax, [ebp-4]
    push    eax
    push    10
    push    rez
    push    ebx
    call    _WriteFile@20
	
	; Beep(dwFreq, dwDuration)
	;push	500
	;push	400
	;push	500
	;push	600
	;push	500
	;push	400
	;call    _Beep@8
	;call    _Beep@8
	;call    _Beep@8

    ; ExitProcess(0)
    push    0
    call    _ExitProcess@4

    ; never here
    hlt
message:
    db      'Hello, World', 10
message_end:
two:
	db 50, 49, 32, 1, 13, 10
two_end:
	db 255
