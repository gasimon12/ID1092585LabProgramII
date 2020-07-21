package main

import (
	"bufio"
	"fmt"
	"os"
	"strconv"
)

type Lista []int

func main() {
	scanner := bufio.NewScanner(os.Stdin)
	num := Read(*scanner)
	for _, v := range num {
		cuadrado := v * v
		fmt.Println(cuadrado)
	}
	fmt.Print("\n")
}

func Read(scanner bufio.Scanner) Lista {
	var i Lista
	for true {
		scanner.Scan()
		t := scanner.Text()
		if err := scanner.Err(); err != nil {
			fmt.Fprintln(os.Stderr, err)
		}
		if t == "" {
			break
		}
		num, err := strconv.Atoi(t)
		if err != nil || num <= 0 {
			fmt.Fprintln(os.Stderr, "Tipo de dato invalido")
		} else {
			i = append(i, num)
		}
	}
	return i
}
