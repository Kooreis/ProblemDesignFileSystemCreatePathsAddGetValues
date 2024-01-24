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