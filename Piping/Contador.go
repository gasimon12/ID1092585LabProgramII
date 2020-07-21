package main

import (
	"fmt"
	"os"
	"strconv"
)

func main() {
	if len(os.Args) > 1 {
		num, err := strconv.Atoi(os.Args[1])
		if err != nil || num <= 0 {
			fmt.Fprintln(os.Stderr, "Tipo de dato no valido")
		}
		for i := 1; i <= num; i++ {
			fmt.Println(i)
		}
	} else {
		fmt.Fprint(os.Stderr, "Debe introducir un numero")
	}
	fmt.Print("\n")
}
