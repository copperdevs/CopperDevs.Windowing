# simple script to quickly generate functions
# wouldn't recommend using, has now been replaced with the CopperDevs.Windowing.SDL3.Generator project
# input  | SDL_OpenURL
# output | public static void OpenURL() => SDL_OpenURL();

import time
import os


def process_file():
    with open("methods.txt", "r") as methods, open("output.txt", "w") as outputFile, open("layer.txt", "w") as layer:
        for line in methods:
            line = line.strip()
            if len(line) >= 4:
                outputFile.write(f"public static void {line[4:]}() => {line}();\n")
                layer.write(f"SDL.SDL3.{line}();\n")


def watch_file(filename, interval=1):
    last_mtime = None
    while True:
        try:
            current_mtime = os.path.getmtime(filename)
            if last_mtime is None or current_mtime != last_mtime:
                print("Detected changes, processing file...")
                process_file()
                last_mtime = current_mtime
        except FileNotFoundError:
            print("Waiting for methods.txt to be created...")
        time.sleep(interval)


if __name__ == "__main__":
    watch_file("methods.txt")
