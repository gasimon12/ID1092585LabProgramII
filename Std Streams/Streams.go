package main

import (
	"bufio"
	"fmt"
	"log"
	"os"
)

func main() {
	path := os.Args[1]
	f, err := os.Open(path)
	if err != nil {
		log.Fatal(err)
	}
	defer func() {
		if err = f.Close(); err != nil {
			log.Fatal(err)
		}
	}()
	s := bufio.NewScanner(f)
	for s.Scan() {
		if len(s.Text()) >= 10 {
			fmt.Fprintln(os.Stderr, s.Text())
		} else {
			fmt.Println(s.Text())
		}
	}
	err = s.Err()
	if err != nil {
		log.Fatal(err)
	}
}
