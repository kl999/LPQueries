    global	_start
	global	_writenum
	global	_add5
	
    extern  _GetStdHandle@4
    extern  _WriteFile@20
    extern  _ExitProcess@4
	extern  _Beep@8
	extern	_ReadConsoleA@20
	extern	_printf

;Uninitialized data
section .bss
	num:	resd 1
	
segment .data
	msg			db 'Hi C', 10, 0
	msg2		db 'ESP adresses:', 10, 0
	strtmsg		db 'Start', 10, 0
	endmsg		db 'End', 10, 0
	fmtdec		db "%d", 10, 0
	fmtstr		db "%s", 0
	arr1		db 0, 0
	
segment .text

printtmth:

	;mov 	ecx, esp
	push	dword 5
	push	fmtdec
	call	_printf
	add     esp, byte 8
	;pop 	ecx
	;pop 	ecx
	
	ret
	;jmp 	end;

espisstackloc:

	mov 	dword [arr1], esp
	push	msg2
	mov 	dword [arr1 + 4], esp
	push	fmtstr
	call	_printf
	add     esp, byte 8
	
	call	writearrnums
	
	ret

writearrnums:
	push	dword [arr1]
	push	fmtdec
	call	_printf
	add     esp, byte 8
	
	push	dword [arr1 + 4]
	push	fmtdec
	call	_printf
	add     esp, byte 8
	
	ret

_writenum:
	
	push	ebp 
	mov 	ebp, esp
	sub 	esp, 0x40
	;pop 	dword [num]
	
	push	400
	push	500
	call    _Beep@8
	
	;push 	dword [ebp + 8]
	;push	fmtdec
	;call	_printf
	;add     esp, byte 8
	
	;push	dword [num]
	
	mov 	esp, ebp
	pop 	ebp 
	
	ret

_add5:
	push	ebp 
	mov 	ebp, esp
	sub 	esp, 0x40
	
	mov 	eax, dword [ebp + 8]
	add 	eax, 5
	
	mov 	esp, ebp
	pop 	ebp
	
	ret
;-----------------------------------------------------

_start:
	
	push	strtmsg
	push	fmtstr
	call	_printf
	add     esp, byte 8

	call	printtmth
	
	call	espisstackloc
	
	push	dword 9
	call 	_add5
	add     esp, byte 4
	
	push	eax
	call	_writenum
	add     esp, byte 4
	
lbl1:
	push	endmsg
	push	fmtstr
	call	_printf
	add     esp, byte 8
	
end:
    ;ExitProcess(0)
    push    0
    call    _ExitProcess@4

    ;never here
    hlt
