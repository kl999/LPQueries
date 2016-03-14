;-------------------------------------------
;c:\sp\nasm\bin\objFile.obj
;-------------------------------------------

	global	_writenum
	global	_add5
	global	_getArr
	global	_createArr
	global	_trueOrNot
	
    extern  _GetStdHandle@4
    extern  _WriteFile@20
    extern  _ExitProcess@4
	extern  _Beep@8
	extern	_ReadConsoleA@20
	extern	_printf
	extern	_GetProcessHeap@0
	extern	_HeapAlloc@12

;------------------------------------------------
section .bss
	num 	resd 1
	
segment .data
	fmtdec		db "%d", 10, 0
	fmtstr		db "%s", 0
	arr			dw 10
				dd $ + 4
	storage		dd 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
	arrlen		dd $ - arr

;------------------------------------------------
segment .text

_writenum:
	
	push	ebp
	mov 	ebp, esp
	sub 	esp, 0x40
	
	push	400
	push	500
	call    _Beep@8
	
	push 	dword[ebp + 8]
	push	fmtdec
	call	_printf
	add     esp, byte 8
	
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

_getArr:
	
	mov 	eax, arr
	
	ret

_createArr:

	push	ebp
	mov 	ebp, esp
	sub 	esp, 0x40
	
	call	_GetProcessHeap@0
	
	;LPVOID WINAPI HeapAlloc(
	;_In_ HANDLE hHeap,
	;_In_ DWORD  dwFlags,
	;_In_ SIZE_T dwBytes
	;)
	push	dword[arrlen]
	push	0
	push	eax
	call	_HeapAlloc@12
	
	;init arr
	mov 	word[eax], 10
	mov 	dword[eax + 2], eax	;eax + 6
	add 	dword[eax + 2], 6	;^ ^ ^
	
	mov 	ecx, 0
	mov 	cx, [eax]
	mov 	ebx, eax
	add 	ebx, storage - arr
	
initArr:
	mov 	dword[ebx], 0
	add 	ebx, 4
	loop	initArr
	
	mov 	dword[eax + 22], 997
	
	mov 	esp, ebp
	pop 	ebp
	
	ret

_trueOrNot:
	
	mov 	eax, 10
	mov 	ebx, 11
	
	cmp 	eax, ebx
	je  	yes
	
	mov 	eax, 0
	jmp 	return
yes:
	mov 	eax, 1

return:
	ret

;-------end--------------------------------------
	
    hlt
	