##Eng Standard
####Github rules
- the interaction with remote sever
  - synchronize the remote change
    - get the change from remote server
      - command: git fetch server (branch)
    - merge the change of remote change to local branch
      - command: git merge server/branch local_branch
  - commit local change to remote
    - create a new remote branch
      - command: git push server local_branch:new_remote_branch
    - create a new pull request to the remote branch needed to merge
      - link: https://help.github.com/en/articles/creating-a-pull-request

####Name rules
- the variable naming rules
  - static variable starts with "s_"
  - class varibles starts with "m_"
  - const variable's first letter should use uppcase
  - variable name uses camel case

####Unity Cares
- Prefer no recursion
- Use stringbuild to construct
- Remove redundant function(like empty Start/Update function)
- Use TryGetValue to access data from dict
