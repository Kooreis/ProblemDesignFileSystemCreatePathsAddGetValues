Here is a TypeScript solution for the problem:

```typescript
class FileSystem {
    private root: any;

    constructor() {
        this.root = {};
    }

    createPath(path: string, value: number): boolean {
        const paths = path.split('/');
        let currentNode = this.root;

        for (let i = 1; i < paths.length - 1; i++) {
            if (!currentNode[paths[i]]) {
                return false;
            }
            currentNode = currentNode[paths[i]];
        }

        if (currentNode[paths[paths.length - 1]]) {
            return false;
        }

        currentNode[paths[paths.length - 1]] = { value: value };
        return true;
    }

    getValue(path: string): number | null {
        const paths = path.split('/');
        let currentNode = this.root;

        for (let i = 1; i < paths.length; i++) {
            if (!currentNode[paths[i]]) {
                return null;
            }
            currentNode = currentNode[paths[i]];
        }

        return currentNode.value;
    }
}

const fs = new FileSystem();
console.log(fs.createPath('/a', 1));  // true
console.log(fs.getValue('/a'));  // 1
console.log(fs.createPath('/a/b', 2));  // true
console.log(fs.getValue('/a/b'));  // 2
console.log(fs.createPath('/c/d', 3));  // false
console.log(fs.getValue('/c'));  // null
```

This solution uses a tree data structure to represent the file system. Each node in the tree is a JavaScript object, where the keys are the names of the subdirectories and the values are the corresponding nodes. The `createPath` method traverses the tree according to the given path and creates a new node at the end. The `getValue` method traverses the tree according to the given path and returns the value of the node at the end.