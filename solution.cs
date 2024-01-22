Here is a simple console application in JavaScript that simulates a file system. It uses a nested object structure to represent directories and files. The `createPath` function creates a new path in the file system and the `addValue` and `getValue` functions allow you to add and retrieve values from files.

```javascript
class FileSystem {
    constructor() {
        this.root = {};
    }

    createPath(path) {
        let current = this.root;
        const parts = path.split('/');
        for (let part of parts) {
            if (!current[part]) {
                current[part] = {};
            }
            current = current[part];
        }
    }

    addValue(path, value) {
        let current = this.root;
        const parts = path.split('/');
        const file = parts.pop();
        for (let part of parts) {
            if (!current[part]) {
                throw new Error(`Path does not exist: ${path}`);
            }
            current = current[part];
        }
        current[file] = value;
    }

    getValue(path) {
        let current = this.root;
        const parts = path.split('/');
        const file = parts.pop();
        for (let part of parts) {
            if (!current[part]) {
                throw new Error(`Path does not exist: ${path}`);
            }
            current = current[part];
        }
        if (!current[file]) {
            throw new Error(`File does not exist: ${path}`);
        }
        return current[file];
    }
}

const fs = new FileSystem();
fs.createPath('dir1/dir2/dir3');
fs.addValue('dir1/dir2/dir3/file1', 'Hello, world!');
console.log(fs.getValue('dir1/dir2/dir3/file1')); // Outputs: Hello, world!
```

This code creates a `FileSystem` class with methods to create paths, add values to files, and get values from files. It uses a nested object structure to represent the file system, with each key in an object representing a directory or file. The `createPath` method creates a new path by splitting the input string into parts and creating new objects for each part. The `addValue` and `getValue` methods navigate to the specified file and add or retrieve the value, respectively.