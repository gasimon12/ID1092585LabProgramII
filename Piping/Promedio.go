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
	sum := 0
	for _, v := range num {
		sum += v
	}
	fmt.Println(sum / len(num))
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
