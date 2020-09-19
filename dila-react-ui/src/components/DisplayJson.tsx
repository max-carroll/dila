import React from 'react';
export const DisplayJson = ({
  object,
  name = null,
  space = 2
}: {
  object: any,
  name?: string | null,
  space?: number
}) => {
  return (
    <>
      {name && <strong>{name}</strong>}
      <code>
        <pre>
          {JSON.stringify(object, null, space)}
        </pre>
      </code>
    </>
  );
};
