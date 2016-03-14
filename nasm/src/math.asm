    global _start
    extern  _GetStdHandle@4
    extern  _WriteFile@20
    extern  _ExitProcess@4
	extern  _Beep@8
	extern	_ReadConsoleA@20
	extern	_printf

section .bss           ;Uninitialized data
	num:	resd 1
	
segment .data
	msg		db 'Hi C', 10, 0
	okmsg	db 'Success', 10, 0
	failmsg	db 'Failure', 10, 0
	fmtnum	db "%d", 10, 0
	fmtstr	db "%s", 0
	arr		dd 1, 3, 7, 15
	loopmsg	db 'Loop 10 times!', 10, 0
	
segment .text
_start:
	
	mov 	dword [num], 5
	
	inc 	dword [num]
	
	push	dword [num]
	push	fmtnum
	call	_printf
	pop 	edx
	
	mov 	dword [num], 5
	
	sub 	dword [num], 6
	
	push	dword [num]
	push	fmtnum
	call	_printf
	pop 	edx
	
	mov 	eax, 5
	mov 	ebx, -3
	
	Imul 	ebx
	
	mov 	dword [num], eax
	
	push	dword [num]
	push	fmtnum
	call	_printf
	pop 	edx
	
	mov 	eax, arr
	;add 	eax, 4
	mov 	dword [num], eax
	add 	dword [num], 4
	add 	dword [num], 4
	mov 	ebx, [num]
	
	push	dword [ebx];dword [eax]
	push	fmtnum
	call	_printf
	pop 	edx
	
	mov 	edx, 0111b
	xor  	edx, 1011b;and or not xor test
	
	push	edx
	push	fmtnum
	call	_printf
	pop 	edx
	
	mov 	eax, 10
	mov 	ebx, 10
	
	cmp 	ebx, eax
	jz  	true
	
	push	failmsg
	push	fmtstr
	call	_printf
	pop 	edx
	
	jmp 	end
	
	true:
	push	okmsg
	push	fmtstr
	call	_printf
	pop 	edx
	
	end:
	
	mov		dword [num], 10
	lbl1:
	
	push	loopmsg
	push	fmtstr
	call	_printf
	pop 	edx
	
	push	dword [num]
	push	fmtnum
	call	_printf
	pop 	edx
	
	dec		dword [num]
	cmp 	dword [num], 0
	jnz		lbl1
	
    ; ExitProcess(0)
    push    0
    call    _ExitProcess@4

    ; never here
    hlt
